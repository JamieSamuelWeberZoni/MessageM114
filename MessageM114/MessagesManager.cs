using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Sodium;
/**
 * Project      : Message M114
 * File         : MessagesManager.cs
 * Description  : A programm that receives and send encrypted messages, this is the manager of the messages we send and receive and the encryption of said messages
 * Authors      : Ballanfat Jeremy, Weber Jamie
 * Date         : 24 May 2023
**/
namespace MessageM114
{
    internal class MessagesManager
    {
        /// <summary>
        /// The end point to the other user
        /// </summary>
        private IPEndPoint endPoint = new(IPAddress.Any, 12345);

        /// <summary>
        /// The nonce of for encrypting
        /// </summary>
        private byte[] nonce = SecretBox.GenerateNonce();

        /// <summary>
        /// The key for encrypting
        /// </summary>
        private byte[] key = SecretBox.GenerateKey();

        /// <summary>
        /// The number of the sequence of messages
        /// </summary>
        private int sequence = 1;

        /// <summary>
        /// The ssrc of the messages
        /// </summary>
        private int ssrc = new Random().Next();

        /// <summary>
        /// The connection to the other user
        /// </summary>
        private TcpClient client = new TcpClient();

        /// <summary>
        /// The stream of data to the other user
        /// </summary>
        private NetworkStream stream;

        /// <summary>
        /// Await an invite from someone and send the infos of incryption and ssrc when invited
        /// </summary>
        /// <returns>Whether there is a connection to someone</returns>
        public async Task<bool> AwaitInvite()
        {
            endPoint = new(IPAddress.Any, 12345);
            Debug.WriteLine("MessagesManager::AwaitInvite   -  endPoint={0}", endPoint);
            TcpListener listener = new TcpListener(endPoint);
            try
            {
                listener.Start();
                client = await listener.AcceptTcpClientAsync();
                stream = client.GetStream();
                byte[] ssrcByte = BitConverter.GetBytes(ssrc);
                byte[] message = new byte[60];
                for(int i = 0; i < nonce.Length; i++)
                {
                    message[i] = nonce[i];
                }
                for (int i = 0; i < key.Length; i++)
                {
                    message[i + nonce.Length] = key[i];
                }
                for (int i = 0; i < ssrcByte.Length; i++)
                {
                    message[i + nonce.Length + key.Length] = ssrcByte[i];
                }
                await stream.WriteAsync(message, 0, message.Length);
                message = new byte[1000];
                int length = await stream.ReadAsync(message);
                string msg = Encoding.UTF8.GetString(message, 0, length);
                if (msg == "ok")
                {
                    ReceiveMessage();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Send an invite to someone and get the infos of incryption and ssrc when accepted
        /// </summary>
        /// <param name="ip">The ip of the person</param>
        /// <returns>Whether there is a connection to someone</returns>
        public async Task<bool> SendInvite(string ip)
        {
            Debug.WriteLine("MessagesManager::SendInvite   -  ip={0}", ip);
            int length = 0;
            byte[] message = new byte[1000];
            try
            {
                byte[] ipBytes = new byte[4];
                string[] ipArray = ip.Split('.');
                for (int i = 0; i < 4; i++)
                {
                    ipBytes[i] = Convert.ToByte(ipArray[i]);
                }
                IPAddress address = new IPAddress(ipBytes);
                endPoint = new IPEndPoint(address, 12345);
                await client.ConnectAsync(endPoint);
                stream = client.GetStream();
                length = await stream.ReadAsync(message);
                Debug.WriteLine("MessagesManager::SendInvite   -  ReadAsync    message={0}    length={1}", message, length);
            }
            catch
            {
                Debug.WriteLine("MessagesManager::SendInvite   -  exception =");
                return false;
            }
            try
            {
                nonce = new byte[24];
                key = new byte[32];
                for (int i = 0; i < 24; i++)
                {
                    nonce[i] = message[i];
                }
                for (int i = 0; i < 32; i++)
                {
                    key[i] = message[i + 24];
                }
                ssrc = BitConverter.ToInt32(message, 56);
                string msg = "ok";
                message = Encoding.UTF8.GetBytes(msg);
                await stream.WriteAsync(message, 0, message.Length);
                ReceiveMessage();
                return true;
            }
            catch
            {
                string msg = "nok";
                message = Encoding.UTF8.GetBytes(msg);
                await stream.WriteAsync(message, 0, message.Length);
                return false;
            }
        }

        /// <summary>
        /// Verify that the ip is in the correct format
        /// </summary>
        /// <param name="ip">The ip to verify</param>
        /// <returns>True if in the correct format, false if not</returns>
        public bool VerifyIp(string ip)
        {
            try
            {
                string[] ipArray = ip.Split('.');
                if (ipArray.Length != 4)
                {
                    return false;
                }
                for (int i = 0; i < 4; i++)
                {
                    Convert.ToByte(ipArray[i]);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Wait to receive a message
        /// </summary>
        private async Task ReceiveMessage()
        {
            while(true)
            {
                byte[] msg = new byte[10000];
                int length = await stream.ReadAsync(msg);
                sequence = BitConverter.ToInt32(msg, 0);
                int essrc = BitConverter.ToInt32(msg, 4);
                if (essrc != ssrc)
                {
                    continue;
                }
                string message = Encoding.UTF8.GetString(msg, 8, length - 8);
                MessageBox.Show(DecryptMessage(message), "Message n." + sequence);
                sequence++;
            }
        }

        public async Task SendMessage(string message)
        {
            byte[] emsg = Encoding.UTF8.GetBytes(message);
            byte[] msg = new byte[8 + emsg.Length];
            byte[] seqByte = BitConverter.GetBytes(sequence);
            byte[] ssrcByte = BitConverter.GetBytes(ssrc);
            for (int i = 0; i < seqByte.Length; i++)
            {
                msg[i] = seqByte[i];
            }
            for (int i = 0; i < ssrcByte.Length; i++)
            {
                msg[i + 4] = ssrcByte[i];
            }
            for (int i = 0; i < emsg.Length; i++)
            {
                msg[i + 8] = emsg[i];
            }
            await stream.WriteAsync(msg, 0, message.Length);
            sequence++;
        }

        /// <summary>
        /// Encrypt a given message
        /// </summary>
        /// <param name="message">The message to encrypt</param>
        /// <returns>The crypted message</returns>
        public string EncryptMessage(string message)
        {
            byte[] enMessage = SecretBox.Create(message, nonce, key);
            return BitConverter.ToString(enMessage);
        }

        /// <summary>
        /// Decrypt a given message
        /// </summary>
        /// <param name="message">The crypted message</param>
        /// <returns>The decrypted message</returns>
        public string DecryptMessage(string message)
        {
            string[] nbrs = message.Split('-');
            byte[] enMessage = new byte[nbrs.Length];
            int i = 0;
            foreach (string nbrHex in nbrs)
            {
                int nbr = int.Parse(nbrHex, System.Globalization.NumberStyles.HexNumber);
                enMessage[i] = Convert.ToByte(nbr);
                i++;
            }
            byte[] deMessage = SecretBox.Open(enMessage, nonce, key);
            string deMessageStr = "";
            foreach (byte charAscii in deMessage)
            {
                deMessageStr += Convert.ToChar(charAscii);
            }
            return deMessageStr;
        }
    }
}
