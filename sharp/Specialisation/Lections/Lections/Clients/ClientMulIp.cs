using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Clients
{
    public class ClientMulIp
    {
        public static void Start()
        {
            using (Socket client = new Socket(
                AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var addresses = Dns.GetHostAddresses("ya.ru");
                Console.WriteLine("Connecting...");
                foreach (var a in addresses)
                {
                    Console.WriteLine(a);
                }

                try
                {
                    client.Connect(addresses, 80);
                    Console.WriteLine("Connected!");
                    Console.WriteLine($"LocalEndPoint: {client.LocalEndPoint}");
                    Console.WriteLine($"RemoteEndPoint: {client.RemoteEndPoint}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка подключения." + ex.Message);
                }
                finally { client.Disconnect(true); }
            }
        }
    }
}
