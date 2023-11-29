using System.Net;
using System.Net.Sockets;
using System.Text;
using global::Seminar2._1;

namespace ClientUdp
{
    public static class Client
    {
        public static void Start(string Nick)
        {
            SendMessage("Alex");
        }

        public static void SendMessage(string Nick)
        {
            var client = new UdpClient();
            var ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);

            while (true)
            {
                string message;

                do
                {
                    message = Console.ReadLine() ?? "";
                } while (string.IsNullOrWhiteSpace(message));
                var mes = new Message()
                {
                    NickNameTo = Nick,
                    NickNameFrom = "Server",
                    Time = DateTime.Now,
                    Text = message
                };
                var json = mes.SerializeMessageToJson();
                var data = Encoding.UTF8.GetBytes(json);

                client.Send(data, data.Length, ipEndPoint);
            }

        }
    }
}

