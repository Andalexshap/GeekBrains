internal class Program
{

    static void PrintThread()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - one");
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - two");
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - three");
        }
    }
    private static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            Thread t = new Thread(PrintThread);
            t.Start();
        }
    }
}