using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Seminar2._1
{
    public static class Server
    {
        public static void Start(string name)
        {
            var endpoint = new IPEndPoint(IPAddress.Any, 0);
            var udpClient = new UdpClient(12345);

            Console.WriteLine("Ожидание сообщений");

            while (true)
            {

                byte[] bufer = udpClient.Receive(ref endpoint);
                if (bufer == null) break;

                var message = Encoding.UTF8.GetString(bufer);

                Message mes = Message.DeserializeJsonToMessage(message);
                Print(mes);
            }
        }

        public static void Print(Message? mes)
        {
            Console.WriteLine(mes?.ToString());
        }
    }
}
