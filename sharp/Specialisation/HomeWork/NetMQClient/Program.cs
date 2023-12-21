using NetMQ;
using NetMQ.Sockets;

internal class Program
{
    static void Client(int number)
    {
        using(var client = new DealerSocket())
        {
            var r = new Random();
            Task.Delay(r.Next(100, 1000)).Wait();

            client.Connect("tcp://127.0.0.1:5556");
            client.SendFrame(number.ToString());

            Task.Delay(r.Next(100, 1000)).Wait();

            var message = client.ReceiveFrameString();
            Console.WriteLine($"Client {number} received frome server: {message}");
        }
    }

    static void Server()
    {
        using(var server = new RouterSocket()) 
        {
            int i = 0;
            server.Bind("tcp://*:5556");
            while (i < 10)
            {
                var message = server.ReceiveMultipartMessage();
                Console.WriteLine($"Получено сообщение: {message.Last.ConvertToString()}");
                Task.Run(() =>
                {
                    var responseMessage = new NetMQMessage();
                    responseMessage.Append(message.First);
                    responseMessage.Append(message.Last.ConvertToString());
                    server.SendMultipartMessage(responseMessage);
                });
                i++;
            }
        }
    }

    static void ServerTopic()
    {
        using (var publisher = new PublisherSocket())
        {
            publisher.Bind("tcp://127.0.0.1:5556");
            while (true)
            {
                Console.WriteLine("Publishint messege to topic1...");
                publisher.SendMoreFrame("topic1").SendFrame("This message with topic1");
                Console.WriteLine("Publishint messege to topic2...");
                publisher.SendMoreFrame("topic1").SendFrame("This message with topic2");
            }
        }
    }

    static void ClientTopic(string topicName)
    {
        using (var subscriber = new SubscriberSocket())
        {
            subscriber.Connect("tcp://127.0.0.1:5556");
            subscriber.Subscribe(topicName);
            while (true)
            {
                var topic = subscriber.ReceiveFrameString();
                var message = subscriber.ReceiveFrameString();
                Console.WriteLine($"{topicName} client received message with topic: '{topic}': {message}");
            }
        }
    }

    static void Main(string[] args)
    {
        /*
        for (int i = 0; i < 10; i++)
        {
            int x = i;
            Task clientTask = Task.Run(() => Client(x));
        }

        Task.Delay(1000).Wait();
        Task serverTask = Task.Run(Server);
        Task.WaitAll(serverTask,Task.Delay(3000));
        */
        Task serverTask = Task.Run(ServerTopic);
        Task.Delay(1000).Wait();
        Task topic1 = Task.Run(() => ClientTopic("topic1"));
        Task topic2 = Task.Run(() => ClientTopic("topic2"));
    }
}