using HomeWork5;

internal class Program
{
    private static void Main(string[] args)
    {
        var calc = new Calc();
        var action = "";
        while (true)
        {
            Console.WriteLine($"Результат: {calc.Result} {action}");
            if (string.IsNullOrEmpty(action))
            {
                Console.WriteLine($"Результат: Выберите действие:");
            }
            else
            {
                Console.WriteLine("Введите число");
            }
            var str = Console.ReadLine();
            switch (str)
            {
                case "+": action = "+"; break;
                case "-": action = "-"; break;
                case "*": action = "*"; break;
                case "/": action = "/"; break;
                case "quit": Environment.Exit(0); break;

                case "DevideByZero":
                    Console.WriteLine("На ноль делить нельзя");
                    break;
                default:
                    if (string.IsNullOrEmpty(action))
                    {
                        Console.WriteLine("Необходим выбор действия!");
                        break;
                    }
                    if (int.TryParse(str, out int number))
                    {
                        calc.Result = action.Equals("+") ? calc.Result + number :
                        calc.Result = action.Equals("-") ? calc.Result - number :
                        calc.Result = action.Equals("*") ? calc.Result * number :
                        calc.Result = action.Equals("/") && number != 0 ? calc.Result / number :
                        calc.Result;

                        action = string.Empty;
                        Console.Clear();
                        if (number == 0) goto case "DevideByZero";
                    }
                    else
                    {
                        Console.WriteLine("Не удалось преобразовать в число");
                        break;
                    }
                    break;
            }
        }
    }

}