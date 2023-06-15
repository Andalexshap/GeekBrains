/*
Задача 29: Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.
1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]
6, 1, 33 -> [6, 1, 33]
*/

Console.WriteLine("Программа, которая задаёт массив из 8 элементов и выводит их на экран.");
Console.WriteLine();

int number = 8;

PrintArray(RandomArray(number));

Console.WriteLine();
Console.Write("А еще можно вывести во так: ");
Console.WriteLine(String.Join(',', RandomArray(number)));


void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (i == 0) Console.Write($"Рандомный массив на {number} элементов: [{array[i]}, ");
        else if (i == array.Length - 1) Console.Write($"{array[i]}]");
        else Console.Write($"{array[i]}, ");
    }
}

int[] RandomArray(int number)
{
    int[] array = new int[number];
    Random rnd = new Random();

    for (int i = 0; i < number - 1; i++)
    {
        array[i] = rnd.Next(-100, 101);
    }

    return array;
}