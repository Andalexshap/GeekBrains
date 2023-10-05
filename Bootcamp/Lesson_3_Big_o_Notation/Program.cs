using System.Diagnostics;
int n = 10;
int[] array = Enumerable.Range(1,n)
                        .Select(i => new Random().Next(10))
                        .ToArray();

Console.WriteLine($"[{string.Join(", ", array)}]");
//O(n)
int sum = 0;
for(int i = 0; i < array.Length; i++)
{
    sum += array[i];
}
Console.WriteLine(sum);


int m = Convert.ToInt32(Console.ReadLine());
int[,] matrix = new int[m,m];

Stopwatch sw = new();
sw.Start();
//способ 1 O(n^2)
for(int i = 1; i <= m; i++)
{
    for(int j = 1; j <= m; j++)
    {
        Console.Write(i * j);
        Console.Write("\t");
    }
    Console.WriteLine();
}
sw.Stop();
Console.WriteLine($"Таблица квадратов Способ 1. Время: {sw.ElapsedMilliseconds}");
sw.Reset();
sw.Start();
//способ 2 O(m^2/2)
for(int i = 1; i <= m; i++)
{
    for(int j = i; j <= m; j++)
    {
        matrix[i-1,j-1] = i*j;
        matrix[j-1,i-1] = i*j;
    }
    Console.WriteLine();
}

for(int i = 0; i<m; i++)
{
    for( int j = 0; j < m; j++)
    {
      Console.Write(matrix[i,j]);
      Console.Write("\t"); 
    }
    Console.WriteLine();
}
sw.Stop();
Console.WriteLine($"Таблица квадратов Способ 2. Время: {sw.ElapsedMilliseconds}");