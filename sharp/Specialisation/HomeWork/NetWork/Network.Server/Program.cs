using Network.Server;

internal class Program
{
        static void Main(string[] args)
        {
            Console.WriteLine("Сервер запущен!");

            var tokenSourse = new CancellationTokenSource();
            var servetToken = tokenSourse.Token;

            Server server = new Server(10,servetToken);
            server.Start();

            Console.ReadLine();
            Environment.Exit(0);
        }
}