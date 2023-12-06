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
        private readonly CancellationToken _ct;

        public Server(int maxCountUsers, CancellationToken ct = default)
        {
            _ct = ct;   
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
                Task task = new(() => HandleClient(),_ct);
                task.Start();
            }
        }

        async void HandleClient()
        {
            Message? message = null;
            try
            {
                byte[] buffer = udpClient.Receive(ref iPEndPoint);
                
                message = await Task.FromResult(_sendGet.FormingMessageForGet(buffer).Result);
                
                if (_ct.IsCancellationRequested)
                {
                    udpClient.Dispose();
                    return;
                }
            }
            catch
            {
                Console.WriteLine("UdpClient закрыт.");
            }

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