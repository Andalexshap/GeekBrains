using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Clients
{
    public class UdpClient
    {
        public static void Start(IPEndPoint endPoint, byte b)
        {
            var sosket = new Socket(AddressFamily.InterNetwork,SocketType.Dgram, ProtocolType.Udp);
            sosket.Bind(endPoint);
            sosket.Connect("127.0.0.1", 12345);
            Send(sosket,new byte[] { b });
        }


        public static void Send(Socket socket, byte[] data)
        {
            for (int i = 0; i < 100; i++)
            {
                socket.Send(data);
            }
            socket.Close();
        }
    }
}
