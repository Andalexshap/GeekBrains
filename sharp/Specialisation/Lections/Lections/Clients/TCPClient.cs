using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Clients
{
    public class TCPClient
    {
        public static void Start()
        {
            using (Socket client = new Socket(
                AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
                Console.WriteLine("Connecting...");

                try
                {
                    client.Connect(remoteEndPoint);
                    Console.WriteLine("Connected!");

                    byte[] data = Encoding.UTF8.GetBytes("Привет");
                    int count = client.Send(data);
                    if (count == data.Length)
                        Console.WriteLine($"Отправлено сообщение '{Encoding.UTF8.GetString(data)}'");
                    else
                        Console.WriteLine("Что то пошло не так");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка подключения." + ex.Message);
                }
                finally { client.Close(); }
            }
        }
    }
}
