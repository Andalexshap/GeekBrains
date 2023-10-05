internal class Program
{
    private static void Main(string[] args)
    {
        //string[] args = { "4", "+", "9", "*", "9", "+", "5", "/", "8", "*", "9", "-", "10", "=" };
        // 4 + 9 * 9 + 5 / 8 * 9 - 10 =
        double result = 0;
        List<double> list = new List<double>();
        if (args.Length > 2)
        {
            list.Add(double.Parse(args[0]));
            for (int i = 2; i < args.Length; i += 2)
            {
                switch (args[i - 1])
                {
                    case "+":
                        list.Add(double.Parse(args[i]));
                        break;
                    case "-":
                        list.Add(-1 * double.Parse(args[i]));
                        break;
                    case "*":
                        var mul = list.Last();
                        mul *= double.Parse(args[i]);
                        list.Remove(list.Last());
                        list.Add(mul);
                        break;
                    case "/":
                        var dev = list.Last();
                        dev /= double.Parse(args[i]);
                        list.Remove(list.Last());
                        list.Add(dev);
                        break;
                    default:
                        list.Add(double.Parse(args[i]));
                        break;
                }
            }
            Console.WriteLine(list.Sum());
        }
        else if (args.Length > 0 || args.Length < 3)
        {
            Console.WriteLine("Need minimum 3 args");
        }
        else
        {
            Console.WriteLine("Need args");
        }
    }
}
