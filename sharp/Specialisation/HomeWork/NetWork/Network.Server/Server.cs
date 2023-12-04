using System.Net.Sockets;
using System.Net;
using Network.SDK.Services;
using Network.SDK.Models;

namespace Network.Server
{
    public class Server : IPrintMessage
    {
        private readonly IGetSend _sendGet = new GetSend();
        UdpClient udpClient;
        IPEndPoint iPEndPoint;
        private readonly int _maxCountUsers;

        public Server(int maxCountUsers)
        {

            _maxCountUsers = maxCountUsers;

        }

        public void Start()
        {
            udpClient = new UdpClient(12345);
            iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            LoopClients();
        }

        void LoopClients()
        {
            for (int i = 0; i < _maxCountUsers; i++)
            {
                Thread thread = new(() => HandleClient());
                thread.Start();
            }
        }

        async void HandleClient()
        {
            byte[] buffer = udpClient.Receive(ref iPEndPoint);

            var message = await Task.FromResult(_sendGet.FormingMessageForGet(buffer).Result);

            if (message is null)
            {
                Console.WriteLine("Ошибка обработки сообщения.");
                return;
            }

            Print(message);

            await SendMessage(new string[3] { "Сообщение принято сервером", "Server", message.NickNameTo.ToString() });
            var a = Console.ReadLine();
        }

        async Task<bool> SendMessage(string[] parts)
        {
            Message message = new Message(parts[0], new User(parts[1]), new User(parts[2]));

            var sendMessage = _sendGet.FormingMessageForSend(message).Result;

            if (sendMessage is null)
                return false;

            await udpClient.SendAsync(sendMessage.Data, sendMessage.Data.Length, iPEndPoint);

            return true;
        }

        public void Print(Message message)
        {
            Console.WriteLine($"\nОт {message.NickNameFrom}\n{message.DateTime:F}\n{message.Text}");
        }
    }
}