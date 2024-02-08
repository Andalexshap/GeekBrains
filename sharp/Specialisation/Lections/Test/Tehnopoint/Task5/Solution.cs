using System.Text;

namespace Tehnopoint.Task5
{
    internal class Solution
    {
        public void Test()
        {
            var count = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < count; i++)
            {
                var resultCount = 2;
                var numbersCount = int.Parse(Console.ReadLine()!);
                if (numbersCount == 1)
                {
                    var value = Console.ReadLine()!;
                    Console.WriteLine(resultCount);
                    Console.WriteLine(value + " 0");
                }
                else
                {
                    StringBuilder result = new StringBuilder();
                    var rangeStr = Console.ReadLine()!;
                    var range = rangeStr.Split(" ").Select(x => int.Parse(x)).ToArray();
                    var repeatCountNegative = 0;
                    var repeatCountPositive = 0;
                    var arrLenght = range.Length;
                    for (int k = 0; k < arrLenght; k++)
                    {
                        if (k == 0)
                        {
                            result.Append(range[k] + " ");
                            continue;
                        }
                        else
                        {
                            var first = range[k];
                            var second = range[k - 1];
                            var temp = first - second;
                            if (temp == 1 && repeatCountNegative == 0)
                            {
                                repeatCountPositive++;
                                if (arrLenght - k == 1) result.Append(repeatCountPositive);
                                continue;
                            }
                            else if (temp == -1 && repeatCountPositive == 0)
                            {
                                repeatCountNegative--;
                                if (arrLenght - k == 1) result.Append(repeatCountNegative);
                                continue;
                            }
                            _ = repeatCountNegative != 0 ? result.Append(repeatCountNegative + " ") :
                                repeatCountPositive != 0 ? result.Append(repeatCountPositive + " ") :
                                    result.Append(0 + " ");
                            result.Append(first + " ");
                            resultCount += 2;
                            if (k == arrLenght - 1)
                                result.Append("0");
                            repeatCountNegative = 0;
                            repeatCountPositive = 0;
                        }
                    }
                    Console.WriteLine(resultCount);
                    Console.WriteLine(result.ToString());
                }
            }
        }
    }
}
