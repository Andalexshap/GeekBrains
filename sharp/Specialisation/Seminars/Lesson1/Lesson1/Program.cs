using System.Diagnostics;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        //сортировка двумерного массива
        /*
         * 732
         * 496
         * 185
         * 
         * 123
         * 456
         * 789
        */

        int[,] matrix =
        {
            { 7, 3, 2 },
            { 4, 9, 6 },
            { 1, 8, 2 }
        };

        int index = 0;
        int[] tempArray = new int[matrix.GetLength(0) * matrix.GetLength(1)];

        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                tempArray[index] = matrix[j, k];
                index++;
            }
        }
        index = 0;
        Array.Sort(tempArray);

        index = 0;
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                matrix[j, k] = tempArray[index];
                index++;
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }

        Console.ReadLine();























        const int n = 1000000;
        var timer = new Stopwatch();
        timer.Start();
        var stringBuilder = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            stringBuilder.Append((char)i);
        }
        timer.Stop();
        Console.WriteLine($"StringBuilder -> {timer.ElapsedMilliseconds}");
        timer.Reset();

        timer.Start();
        stringBuilder.ToString();
        timer.Stop();
        Console.WriteLine($"StringBuilder.ToString() -> {timer.ElapsedMilliseconds}");

        timer.Start();
        var charList = new List<char>();
        for (int i = 0; i < n; i++)
        {
            charList.Add((char)i);
        }
        timer.Stop();
        Console.WriteLine($"List<char>() -> {timer.ElapsedMilliseconds}");
        timer.Reset();

        timer.Start();
        String.Join("", charList);
        timer.Stop();
        Console.WriteLine($"String.Join(\"\", charList) -> {timer.ElapsedMilliseconds}");
        Console.ReadKey();











        //string[] args = { "4", "+", "9", "*", "9", "+", "5", "/", "8", "*", "9", "-", "10", "+", "5", "=" };
        // 4 + 9 * 9 + 5 / 8 * 9 - 10 =
        List<double> list = new List<double>();
        if (args.Length > 2)
        {
            try
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
                            if (dev == 0)
                            {
                                Console.WriteLine("На ноль делить нельзя!");
                                return;
                            }
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
            catch
            {
                Console.WriteLine("Ошибка в аргументах");
                return;
            }
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
