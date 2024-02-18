using System;

public class Program
{
    public static void Main()
    {
        var data = new TestClass();
        data.Data = 1;
        //Method(data);
        Method2(data);
        Console.WriteLine(data.Data);

    }
    public static void Method(TestClass data)
    {
        data.Data = 2;
        Console.WriteLine(  data.Data);
    }
    public static void Method2(TestClass data)
    {
        data = new TestClass();
        data.Data = 2;
        Console.WriteLine(data.Data);
    }

    public class TestClass
    {
        public int Data { get; set; }
    }
}