using HomeWork6;

namespace DZ5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //заменить Convert.ToDouble на собственный DoubleTryPars и обрабатываем ошибку
                //проверить что введенное число небыло отрицательное (вывести ошибку Exeption , отловить Catch)
                //сумма не может быть отрицательной (при вычитании)

                var calc = new Calc();
                calc.MyEventHandler += Calc_MyEventHandler;

                Console.WriteLine("Enter first number");
                Console.ReadLine().DoubleTryParse(out double number1);
                Console.WriteLine("Enter second number");
                Console.ReadLine().DoubleTryParse(out double number2);
                Console.WriteLine("Select an action \n1. + \n2. - \n3. / \n4. *");
                int symbol = Convert.ToInt32(Console.ReadLine());

                switch (symbol)
                {
                    case 1: calc.Sum(number1, number2); break;
                    case 2: calc.Sub(number1, number2); break;
                    case 3:
                        try
                        {
                            calc.Divide(number1, number2);
                        }
                        catch (CalculatorDivideByZeroException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (CalculatorExeption ex)
                        {
                            Console.WriteLine(ex);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case 4: calc.Multy(number1, number2); break;
                }
                Console.WriteLine("Continue ?");
                Console.WriteLine("Press F to finish");

                if (Console.ReadKey().Key == ConsoleKey.F)
                {
                    break;
                }
                Console.Clear();
            }
        }

        private static void Calc_MyEventHandler(object? sender, EventArgs e)
        {
            if (sender is Calc)
            {
                Console.WriteLine($"Answer: {((Calc)sender).Result}");
            }
        }
    }
}