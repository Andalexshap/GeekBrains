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

        var nums = Enumerable.Range(0, 50).Select(i => i).ToArray();


    }

    public void FindTermOfTarget(IEnumerable<int> nums, int target)
    {
        var error = "Невозможно составить слагаемые из представленых чисел";

        var firstPossibleTerm = nums.Where(f => f < target);
        if (!firstPossibleTerm.Any())
        {
            var secondPossibleTerm =
                firstPossibleTerm.Where(x => target - x < target);

            if (!secondPossibleTerm.Any())
            {

            }
        }

        Console.WriteLine(error);

    }
}