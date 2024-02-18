internal class Program
{
    private static void Main(string[] args)
    {
        var a = new Class1();
        Console.WriteLine(a.Test1());


    }
}
public interface IInterface1
{
    int Test1();
}
public interface IInterface2
{
    int Test1();
}
public class Class1 : IInterface1, IInterface2
{
    public int Test1()
    {
        if (this is IInterface1)
            return 1;
        else if (this is IInterface2)
            return 2;
        return 0;
    }
}
