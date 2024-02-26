internal class Program
{
    private static void Main(string[] args)
    {
        Human human = new Man();
        human.Eat(); 
        human.Sleep();

        Foo(human);

        IHuman ihiman1 = human;
        ihiman1.Eat(); 
        ihiman1.Sleep(); 

        Human human2 = ihiman1 as Human;
        human2.Eat(); 
        human2.Sleep(); 

        Man man = human2 as Man;
        man.Eat(); 
        man.Sleep(); 

        Foo(man);

        Human human3 = new Human();
        IHuman ihuman2 = human3 as Man;
        ihuman2.Eat();
    }
    public static void Foo(IHuman i)
    {
        i.Eat();
        i.Sleep();
    }
}
public interface IHuman
{
    void Eat();
    void Sleep();
}

public class Human : IHuman
{
    public virtual void Eat() { Console.WriteLine("Eat as Human"); }
    public virtual void Sleep() { Console.WriteLine("Sleep as Human"); }
}

public class Man : Human
{
    public override void Eat() { Console.WriteLine("Eat as Man"); }
    public new void Sleep() { Console.WriteLine("Sleep As Man"); }
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
        if (this is IInterface1 || this is IInterface2)
            return 1;
        return 0;
    }
}

