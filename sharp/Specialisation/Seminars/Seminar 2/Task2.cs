namespace Seminar_2
{
    public class Task2
    {
        /*
         * Дан список целых чисел (числа не последовательны), 
         * в котором некоторые числа повторяются.  Выведите список чисел на экран, 
         * расположив их в порядке возрастания частоты повторения*/

        public void Solution()
        {
            List<int> ints = new List<int> { 1, 2, 2, 2, 3, 4, 4, 5, 5, 5, 5, 6, 7, 0 };

            var dict = new Dictionary<int, int>();

            foreach (var item in ints)
            {
                if (dict.ContainsKey(item)) dict[item]++;
                else dict[item] = 1;
            }

            dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in dict)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
