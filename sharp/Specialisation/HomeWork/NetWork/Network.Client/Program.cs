using Network.Client;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите ваш NickName: ");
        Console.Write("> ");
        var nick = Console.ReadLine();
        
        Console.WriteLine("Введите через двоеточие:\nNickName кому хотите отправить сообщение и Текст:");

        Client client = new("127.0.0.1", nick);
        client.Start();

        Console.ReadLine();
    }
}