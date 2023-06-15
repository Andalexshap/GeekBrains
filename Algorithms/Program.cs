using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Algorithms.Models;
using Algorithms.Services;

Stopwatch stopwatch = new Stopwatch();

int[] array = AlgorithmService.CreateRandomIntArray(10);

#region AlgorithmSortings

#region BubbleSort
int[] bubbleSortArray = AlgorithmService.Copy(array);

stopwatch.Start();
bubbleSortArray.BubbleSort(out var bubbleSortCount);
stopwatch.Stop();

Console.WriteLine(/*String.Join(" ", bubbleSortArray) + */$"\nВремя выполнения {nameof(bubbleSortArray)}: {stopwatch.ElapsedMilliseconds} \n" +
    $"Колличество операций: {bubbleSortCount}");
#endregion

#region DirectSort
int[] directSortArray = AlgorithmService.Copy(array);

stopwatch.Start();
directSortArray.DirectSort(out var directSortCount);
stopwatch.Stop();

Console.WriteLine(/*String.Join(" ", directSortArray) + */$"\nВремя выполнения {nameof(directSortArray)}: {stopwatch.ElapsedMilliseconds} \n" +
    $"Колличество операций: {directSortCount}");
#endregion

#region InsertSort
int[] InsertSortArray = AlgorithmService.Copy(array);

stopwatch.Start();
InsertSortArray.InsertSort(out var InsertSortCount);
stopwatch.Stop();

Console.WriteLine(/*String.Join(" ", InsertSortArray) + */$"\nВремя выполнения {nameof(InsertSortArray)}: {stopwatch.ElapsedMilliseconds} \n" +
    $"Колличество операций: {InsertSortCount}");
#endregion

#region QuickSort
int[] quickSortArray = AlgorithmService.Copy(array);

stopwatch.Start();
InsertSortArray.QuickSort(0, quickSortArray.Length - 1, out var quickSortCount);
stopwatch.Stop();

Console.WriteLine(/*String.Join(" ", QuickSortArray) + */$"\nВремя выполнения {nameof(quickSortArray)}: {stopwatch.ElapsedMilliseconds} \n" +
    $"Колличество операций: {quickSortCount}");
#endregion

#region HeapSort
int[] heapSortArray = AlgorithmService.Copy(array);

stopwatch.Start();
heapSortArray.HeapSort(out int heapSortCount);
stopwatch.Stop();

Console.WriteLine(/*String.Join(" ", heapSortArray) + */$"\nВремя выполнения {nameof(heapSortArray)}: {stopwatch.ElapsedMilliseconds} \n" +
    $"Колличество операций: {heapSortCount}");
#endregion

#endregion

#region AlgorithmSearchings

#region Search

var targetValue = new Random().Next(0,array.Length);
stopwatch.Start();
var result = SearchService.Search(array, targetValue);
stopwatch.Stop();

Console.WriteLine($"\nОбычный пойск. \nИскомое значение: {targetValue}\nВремя выполнения: {stopwatch.ElapsedMilliseconds}\n" +
    $"Колличество операций: {result.counter}\nИскомый индекс:{result.index}\n");

#endregion

#region BinarySearch
stopwatch.Start();
result = SearchService.BinarySearch(array, targetValue,0, array.Length-1);
stopwatch.Stop();

Console.WriteLine($"\nБинарный поиск. \nИскомое значение: {targetValue}\nВремя выполнения: {stopwatch.ElapsedMilliseconds}\n" +
    $"Колличество операций: {result.counter}\nИскомый индекс:{result.index}\n");

#endregion

#endregion

#region LinkedList
var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToList();


var tempAlphabet = alphabet.Select(x => new LinkedListNode<char>(x)).ToList();
LinkedList<LinkedListNode<char>> linkedAlfabet = new();

linkedAlfabet.AddLastRange(tempAlphabet);

Console.WriteLine(String.Join(" : ", linkedAlfabet.Select(x => x.Value)));

linkedAlfabet.Reverse();

Console.WriteLine(String.Join(" : ", linkedAlfabet.Select(x => x.Value)));

#endregion

#region Queue
var queue = new Queue<char>();

Console.WriteLine($"\n{nameof(queue)}:\n");

alphabet.ForEach(x => queue.Enqueue(x));

Console.WriteLine(String.Join(" : ", queue));

var reverseQueue = queue.Reverse();

Console.WriteLine(String.Join(" : ", reverseQueue));

#endregion

#region LinkList
LinkList<char> linkList = new LinkList<char>();

Console.WriteLine($"\n{nameof(linkList)}:\n");

alphabet.ForEach(linkList.AddLast);

Console.WriteLine(String.Join(" : ", linkList));




#endregion

