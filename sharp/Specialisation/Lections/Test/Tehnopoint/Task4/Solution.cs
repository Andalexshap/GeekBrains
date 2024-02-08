


namespace Tehnopoint.Task4
{
    internal class Solution
    {
        public void Test()
        {
            var count = int.Parse(Console.ReadLine()!.Trim('\r'));
            var rangeTemp = new int[] { 15, 30 };
            for (int i = 0; i < count; i++)
            {
                var request = Console.ReadLine()!.Trim('\r');
                
                int rangePeople = int.Parse(request);
                for (int k = 0; k < rangePeople; k++)
                {
                    var condition = Console.ReadLine()!.Trim('\r');

                    if (rangeTemp[0] > rangeTemp[1])
                    {
                        Console.WriteLine("-1");
                        continue;
                    }

                    var tempValue = int.Parse(condition.Substring(2));
                    switch (condition.Substring(0, 2))
                    {
                        case "<=":
                            if (rangeTemp[1] >= tempValue)
                                rangeTemp[1] = int.Parse(condition.Substring(2));
                            break;
                        case ">=":
                            if (rangeTemp[0] <= tempValue)
                                rangeTemp[0] = int.Parse(condition.Substring(2));
                            break;
                    }

                    if (rangeTemp[0] > rangeTemp[1])
                        Console.WriteLine("-1");
                    else
                        Console.WriteLine(rangeTemp[0]);
                }
                rangeTemp[0] = 15;
                rangeTemp[1] = 30;
                Console.WriteLine();
            }
        }
    }
}
