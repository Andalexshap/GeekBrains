namespace Tehnopoint.Task18
{
    internal class Solution
    {
        public void Test()
        {
            int t = int.Parse(Console.ReadLine()); // Читаем количество наборов входных данных

            for (int testCase = 0; testCase < t; testCase++)
            {
                int n = int.Parse(Console.ReadLine()); // Читаем длину массива a
                int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse); // Читаем массив a

                int[] seasons = new int[n]; // Массив для хранения количества сезонов для каждого k

                for (int k = 1; k <= n; k++)
                {
                    int start = 0;
                    int end = 0;
                    int maxSeasons = 0;

                    while (end < n)
                    {
                        // Увеличиваем end до тех пор, пока последовательность a[start:end] является k-сезонной историей
                        while (end + 1 < n && (a[end] < a[end + 1] || a[end] > a[end + 1]))
                        {
                            end++;
                        }

                        int seasonsCount = end - start + 1;

                        // Обновляем максимальное количество сезонов
                        if (seasonsCount > maxSeasons)
                        {
                            maxSeasons = seasonsCount;
                        }

                        // Переходим к следующей подпоследовательности
                        start = end + 1;
                        end = start;
                    }

                    seasons[k - 1] = maxSeasons;
                }

                // Выводим результаты для данного набора входных данных
                Console.WriteLine(string.Join(" ", seasons));
            }
        }
    }
}
//if (new[] { 'M', 'R', 'C', 'D' }.Contains(preview))
//(1≤t≤5⋅10^5)