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

        IPEndPoint iPEndPoint = new (IPAddress.Any, 12345);

        public async Task<string> listener()
        {

            TcpListener listener = new TcpListener(iPEndPoint);

            try
            {

                listener.Start();

                using TcpClient handler = await listener.AcceptTcpClientAsync();
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
