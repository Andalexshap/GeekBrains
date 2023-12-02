using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCP_UDP_DNS
{
    public class SocketListener
    {
        public static void Start()
        {
            using (Socket listener = new Socket(
                AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);

                listener.Blocking = true; //Заставляем совершать все операции в блокирующем основной поток режиме
                listener.Bind(localEndPoint); //Приязываем сокет к IP адресу и порту
                listener.Listen(100); //переводит сокет в режим прослушивания

                Console.WriteLine("Waiting for connection...");

                var socket = listener.Accept(); //Ожидает содение и блокирует выполнение приложения до выполнения соеденения
                Console.WriteLine("Connected!");

                byte[] buffer = new byte[1024];
                int count = socket.Receive(buffer);
                if (count > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine($"Получено сообщение '{message}'");
                }
                else
                {
                    Console.WriteLine("Сообщение не получено");
                }
                listener.Close();
            }
        }
    }
}
