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

        var nums = new HashSet<int>(Enumerable.Range(0, 50).Select(i => i));

        FindTermOfTarget(nums, 10);

    }

    public static void FindTermOfTarget(HashSet<int> nums, int target)
    {
        var error = "Невозможно составить слагаемые из представленых чисел";

        var firstPossibleTerm = nums.Where(f => f < target);

        if (!firstPossibleTerm.Any())
        {
            var secondPossibleTerm =
                firstPossibleTerm.Where(x => target - x < target).Select(x => new
                {
                    firstTerm = x,
                    secondTerm = () =>
                    {
                        if (firstPossibleTerm.Contains(target - x)) return target - x;
                        else return 0;
                    }
                }).Where;
        }

        Console.WriteLine(error);

    }
}