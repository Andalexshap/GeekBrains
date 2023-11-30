using Network.Server;

internal class Program
{
        static void Main(string[] args)
        {
            Console.WriteLine("Сервер запущен!");

            Server server = new Server(10);
            server.Start();
            Console.ReadLine();
        }
}