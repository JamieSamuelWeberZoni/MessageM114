using System;
using System.Collections.Generic;
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
        private IPEndPoint endPoint = new(IPAddress.Any, 12345);
        private byte[] nonce = SecretBox.GenerateNonce();
        private byte[] key = SecretBox.GenerateKey();
        private int sequence = 0;
        private int ssrc = new Random().Next();
        private TcpClient client = new TcpClient();

        /// <summary>
        /// Await an invite from someone and send the infos of incryption and ssrc when invited
        /// </summary>
        /// <returns>Whether there is a connection to someone</returns>
        public async Task<bool> AwaitInvite()
        {
            endPoint = new(IPAddress.Any, 12345);
            TcpListener listener = new TcpListener(endPoint);
            try
            {
                listener.Start();
                client = await listener.AcceptTcpClientAsync();
                await using NetworkStream stream = client.GetStream();
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
            int length = 0;
            byte[] message = new byte[1000];
            NetworkStream stream = null;
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
                await using NetworkStream st = client.GetStream();
                stream = st;
                length = await stream.ReadAsync(message);
            }
            catch
            {
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


    }
}
