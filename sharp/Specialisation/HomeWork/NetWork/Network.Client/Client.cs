using System.Net.Sockets;
using System.Net;
using Network.SDK.Services;
using Network.SDK.Models;

namespace Network.Client
{
    public class Client : IPrintMessage
    {
        private readonly IGetSend _sendGet = new GetSend();
        private string _ip = string.Empty;
        private readonly string _nickName;
        private UdpClient udpClient;
        private IPEndPoint iPEndPoint;

        public Client(string ip, string nickName)
        {
            _nickName = nickName;
            _ip = ip;            
        }

        public void Start()
        {
            udpClient = new UdpClient();
            iPEndPoint = new IPEndPoint(IPAddress.Parse(_ip), 12345);
            HandleCommunication();
        }

        async void HandleCommunication()
        {
            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (input == null || string.IsNullOrEmpty(input))
                    continue;

                var parts = input.Trim().Split(':', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                {
                    Console.WriteLine("Неверный формат ввода. Попробуйте снова.");
                    continue;
                }
                if (await SendMessage(parts))
                    await GetMessage();
                else Console.WriteLine("Ошибка отправки сообщения");

            }
        }

        async Task<bool> SendMessage(string[] parts)
        {
            Message message = new Message(parts[1], new User(_nickName), new User(parts[0]));

            var sendMessage = _sendGet.FormingMessageForSend(message).Result;

            if (sendMessage is null)
                return false;

            await udpClient.SendAsync(sendMessage.Data, sendMessage.Data.Length, iPEndPoint);

            return true;
        }

        async Task GetMessage()
        {
            byte[] buffer = udpClient.Receive(ref iPEndPoint);

            var getMessage = await Task.FromResult(_sendGet.FormingMessageForGet(buffer).Result);

            if (getMessage is null)
                Console.WriteLine("Ошибка обработки сообщения.");

            Print(getMessage);

        }

        public void Print(Message message)
        {
            Console.WriteLine($"От {message.NickNameFrom}\n{message.DateTime:F}\n{message.Text}");
        }
    }
}