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

        public async void createIPEndpoint()
        {

            if(iPEndPoint != null)
            {

                iPEndPoint = new(IPAddress.Any, 15245);

            }

        }

        public async Task<string> listener()
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
