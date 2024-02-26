using System;

public static class Program
{
    public static void Main()
    {
        A a1 = new B();
        a1.F1(); // B::F1()
        a1.F2(); // A::F2()

        Foo(a1); // B::F1()
                 // A::F2()

        I x1 = a1;
        x1.F1(); // B::F1()
        x1.F2(); // A::F2()

        A a2 = x1 as A;
        a2.F1(); // A::F1()
        a2.F2(); // A::F2()

        B b1 = a2 as B;
        b1.F1();
        b1.F2();

        Foo(b1);

        A a3 = new A();
        I x2 = a3 as B;
        x2.F1();
    }

    public static void Foo(I i)
    {
        i.F1();
        i.F2();
    }
}

public interface I
{
    void F1();
    void F2();
}

public class A : I
{
    public virtual void F1() { Console.WriteLine("A::F1()"); }
    public virtual void F2() { Console.WriteLine("A::F2()"); }
}

public class B : A
{
    public override void F1() { Console.WriteLine("B::F1()"); }
    public new void F2() { Console.WriteLine("B::F2()"); }
}