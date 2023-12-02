using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TCP_UDP_DNS
{
    internal class ServerUdp
    {
        public static void Start()
        {
            using (Socket socket = new Socket(
                AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                var localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);

                socket.Bind(localEndPoint); //Приязываем сокет к IP адресу и порту

                byte[] buffer = new byte[1024];
                int count = 0;
                while (count < 200) 
                {
                    int c = socket.Receive(buffer);
                    if(c == 1)
                    {
                        Console.Write(buffer[0]);
                    }
                    count += c;
                    
                }
                Console.WriteLine("\nПрочитали 200 байт");
            }
        }
    }
}
