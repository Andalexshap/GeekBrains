namespace Tehnopoint.Task14
{
    internal class Solution
    {
        public void Test()
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                string[] nm = Console.ReadLine().Split();
                int n = int.Parse(nm[0]);
                int m = int.Parse(nm[1]);

                char[][] warehouse = new char[n][];
                for (int j = 0; j < n; j++)
                {
                    warehouse[j] = Console.ReadLine().ToCharArray();
                }

                // Поиск свободных клеток для роботов A и B
                int aRow = -1, aCol = -1;
                int bRow = -1, bCol = -1;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < m; col++)
                    {
                        if (warehouse[row][col] == 'A')
                        {
                            aRow = row;
                            aCol = col;
                        }
                        else if (warehouse[row][col] == 'B')
                        {
                            bRow = row;
                            bCol = col;
                        }
                    }
                }

                // Построение маршрутов для роботов A и B
                string[] routeA = BuildRoute(aRow, aCol, 0, 0);
                string[] routeB = BuildRoute(bRow, bCol, n - 1, m - 1);

                // Вывод результатов
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < m; col++)
                    {
                        if (warehouse[row][col] == '.')
                        {
                            if (routeA[row][col] == 'X')
                                warehouse[row][col] = 'a';
                            if (routeB[row][col] == 'X')
                                warehouse[row][col] = 'b';
                        }
                    }
                    Console.WriteLine(new string(warehouse[row]));
                }
            }
        }

        // Функция для построения маршрута от начальной клетки до конечной клетки
        static string[] BuildRoute(int startRow, int startCol, int endRow, int endCol)
        {
            int numRows = Math.Abs(startRow - endRow) + 1;
            int numCols = Math.Abs(startCol - endCol) + 1;
            string[] route = new string[numRows];

            // Построение вертикального маршрута
            if (startCol == endCol)
            {
                char direction = startRow < endRow ? 'D' : 'U';
                for (int i = 0; i < numRows; i++)
                {
                    route[i] = direction.ToString();
                }
            }
            // Построение горизонтального маршрута
            else if (startRow == endRow)
            {
                char direction = startCol < endCol ? 'R' : 'L';
                route[0] = new string(direction, numCols);
            }
            // Построение диагонального маршрута
            else
            {
                char verticalDirection = startRow < endRow ? 'D' : 'U';
                char horizontalDirection = startCol < endCol ? 'R' : 'L';
                route[0] = new string(horizontalDirection, numCols);
                for (int i = 1; i < numRows; i++)
                {
                    route[i] = verticalDirection.ToString() + new string('X', numCols - 2) + verticalDirection.ToString();
                }
            }

            return route;
        }
    }
}
//if (new[] { 'M', 'R', 'C', 'D' }.Contains(preview))
