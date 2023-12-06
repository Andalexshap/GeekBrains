using Network.Server;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Сервер запущен!");

        var tokenSourse = new CancellationTokenSource();
        var serverToken = tokenSourse.Token;

        Server server = new Server(10, serverToken);
        server.Start();

        Console.ReadLine();
        tokenSourse.Cancel();
        Console.WriteLine("Сервер остановлен, нажмите любую клавишу для завершения работы приложения");
        Console.ReadKey();
        Environment.Exit(0);
    }
}