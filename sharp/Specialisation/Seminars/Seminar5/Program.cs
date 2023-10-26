using Seminar5;

internal class Program
{
    delegate void myDelegate(string message);
    private static void Main(string[] args)
    {
        /*
        List<Action> actions = new List<Action> { Print, PrintSecond };
        List<myDelegate> delegateList = new List<myDelegate>()
        {
            (message) => Console.WriteLine($"Первый делегат " + message),
            (message) => Console.WriteLine($"Второй делегат " + message)
        };

        //Task1(actions);
        //Task2(delegateList);*/

        var calc = new Calc();
        calc.MyEventHandler += Calc_MyEventHandler;
        calc.Sum(10);
        calc.Sub(1);
        calc.Multy(5);
        calc.Divide(3);
        calc.CancelLast();
        calc.CancelLast();
        calc.CancelLast();
        calc.CancelLast();
        calc.CancelLast();
    }

    private static void Calc_MyEventHandler(object? sender, EventArgs e)
    {
        if (sender is Calc)
            Console.WriteLine(((Calc)sender).Result);
    }

    //Спроектируем интерфейс калькулятора, поддерживающего простые
    //арифметические действия, хранящего результат и также способного
    //выводить информацию о результате  при помощи события




    static void Task2(List<myDelegate> delegateList)
    {
        delegateList.ForEach(x => x("Привет"));
    }


    //Создайте метод, который принимает список действий(делегат Action)
    //и выполняет их последовательно.

    public static void Task1(List<Action> actions)
    {
        actions.ForEach(action => Console.WriteLine());
    }

    public static void Print()
    {
        Console.WriteLine("Print");
    }

    public static void PrintSecond() { Console.WriteLine(); }

}
