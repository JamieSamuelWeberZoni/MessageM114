using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace MessageM114
{
    internal class Sender
    {
        public Sender()
        {

        }

        /// <summary>
        /// Send a given message to someone with the given IP
        /// </summary>
        /// <param name="ip">The ip of the person</param>
        /// <param name="msg">The message of the person</param>
        public async Task<bool> SendMessage(string ip, string msg)
        {
            try
            {
                byte[] ipBytes = new byte[4];
                string[] ipArray = ip.Split('.');
                for (int i = 0; i < 4; i++)
                {
                    ipBytes[i] = Convert.ToByte(ipArray[i]);
                }
                IPAddress address = new IPAddress(ipBytes);
                IPEndPoint endPoint = new IPEndPoint(address, 12345);
                TcpClient client = new TcpClient();
                await client.ConnectAsync(endPoint);
                await using NetworkStream stream = client.GetStream();
                byte[] msgByte = Encoding.UTF8.GetBytes(msg);
                await stream.WriteAsync(msgByte, 0, msgByte.Length);
                return true;
            }
            catch
            {
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

    }
}
