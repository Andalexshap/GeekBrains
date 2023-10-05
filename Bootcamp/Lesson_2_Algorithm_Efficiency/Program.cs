using System.Diagnostics;
// array - 1_000_000
// найти максимальную сумму N-элесентов

const int ArraySize = 1000;
const int N = 300;

int[] array = Enumerable.Range(1,ArraySize)
                        .Select(i => Random.Shared.Next(10))
                        .ToArray();

//Console.WriteLine(($"[{string.Join(", ", array)}]"));
Stopwatch sw = new();
sw.Start();
//Способ 1
int maxSum = 0;

for(int i = 0; i < array.Length - N; i++)
{
    int tempSum = 0;
    for(int j = i; j < i + N; j++) 
    {
      tempSum += array[j];
    }
    if(tempSum > maxSum) maxSum = tempSum;
}
sw.Stop();
Console.WriteLine($"time Способ 1 = {sw.ElapsedMilliseconds}");
Console.WriteLine($"Способ 1: {maxSum}");

//Способ 2
sw.Reset();
sw.Start();
int maxSum1 = 0;
for(int j = 0; j < N; j++) maxSum1 += array[j];
int tempSum1 = maxSum1;
for(int i = 1; i < array.Length - N; i++)
{
  tempSum1 = tempSum1 - array[i-1] + array[i+(N-1)];
  if(tempSum1 > maxSum1) maxSum1 = tempSum1;
}
sw.Stop();
Console.WriteLine($"time Способ 2 = {sw.ElapsedMilliseconds}");
Console.WriteLine($"Способ 2: {maxSum1}");

