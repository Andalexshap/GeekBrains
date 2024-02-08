using System;

public class Program
{

    public class A
    {
        public virtual void Print1()
        {
            Console.Write("A");
        }
        public void Print2()
        {
            Console.Write("A");
        }
    }
    public class B : A
    {
        public override void Print1()
        {
            Console.Write("B");
        }
    }
    public class C : B
    {
        new public void Print2()
        {
            Console.Write("C");
        }
    }

    public static void Main()
    {
        var c = new C();
        A a = c;

        a.Print2();
        a.Print1();
        c.Print2();
    }
}