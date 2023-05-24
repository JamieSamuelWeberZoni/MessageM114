using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MessageM114
{
    internal class Receive
    {

        IPEndPoint iPEndPoint;

        public async void creatIPEndpoint(string ip)
        {

            if(iPEndPoint != null)
            {

                IPHostEntry iPHostInfo = await Dns.GetHostEntryAsync(ip);
                IPAddress iPAdress = iPHostInfo.AddressList[0];

                iPEndPoint = new (iPAdress, 15245);

            }

        }

        public async Task<string> creatTcpListener()
        {

            TcpListener listener = new(iPEndPoint);

            try
            {

                listener.Start();

                using TcpClient handler = await listener.AcceptTcpClientAsync();
                await handler.ConnectAsync(iPEndPoint);
                await using NetworkStream stream = handler.GetStream();

                byte[] buffer = new byte[10000];
                int received = await stream.ReadAsync(buffer);

                string message = Encoding.UTF8.GetString(buffer, 0, received);

                return message;

            }
            finally
            {

                listener.Stop();

            }

        }

    }

}
