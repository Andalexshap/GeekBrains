internal class Program
{
    private static void Main(string[] args)
    {
        /*
         Дан массив и число. Найдите три числа в массиве сумма 
        которых равна искомому числу. 
        Подсказка: если взять первое число в массиве, можно ли найти 
        в оставшейся его части два числа равных по сумме первому.
        */

        var nums = Enumerable.Range(0, 50).Select(i => i);

        FindTermOfTarget(nums, 100);

    }

    public static void FindTermOfTarget(IEnumerable<int> numbers, int target)
    {
        var nums = numbers.OrderBy(x => x).ToArray(); 
        
        var result = new List<(int, int, int)>();

        for (int i = 0; i < nums.Count() - 2; i++)
        {
            int left = i + 1;
            int right = nums.Count() - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];

                if (sum == target)
                {
                    // Нашли комбинацию трех чисел
                    result.Add((nums[i], nums[left], nums[right]));
                    break;
                }
                else if (sum < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        if (result.Any()) result.ForEach(x => Console.WriteLine($"Возможные слагаемые : {x.Item1}, {x.Item2}, {x.Item3}"));
        else Console.WriteLine("Невозможно составить слагаемые из представленых чисел");
    }
}