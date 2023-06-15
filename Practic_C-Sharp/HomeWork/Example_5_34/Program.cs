/*
Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, 
которая покажет количество чётных чисел в массиве.
[345, 897, 568, 234] -> 2
*/

Console.WriteLine("Программая для создание рандомно заполененого массива и подсчет четных элементов");

var size = InputNumber();
var array = CreateArrayRndInt(size);

PrintArray(array);

var positivNumbers = array.Count(x => x % 2 == 0);

Console.WriteLine($"Колличество положительных чисел в созданном массиве, равно: {positivNumbers}");



#region Methods
int InputNumber()
{
    int count = 0;
    while (true)
    {
        Console.WriteLine("Введите размер массива: ");
        var firstResult = int.TryParse(Console.ReadLine(), out var number);

        if (!firstResult)
        {
            count++;
            if (count >= 5)
            {
                Console.WriteLine("Извините, у нас Обед!!! Нажмите любую клавишу:");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.WriteLine("Введены некоректные данные. Введите ЧИСЛО еще раз!");
            Thread.Sleep(1500);

            continue;
        }

        if (number <= 0)
        {
            Console.WriteLine("Размер массива не может быть отрицательным или равен нулю!");
            Thread.Sleep(1500);

            continue;
        }

        return number;
    }
}

int[] CreateArrayRndInt(int size)
{
    int[] array = new int[size];
    var rnd = new Random();

    for (int i = 0; i < size; i++)
    {
        array[i] = rnd.Next(100, 1000);
    }

    return array;
}

void PrintArray(int[] array)
{
    Console.Write("Полученный массив: [");

    for (int i = 0; i < array.Length; i++)
    {
        if (i == array.Length - 1) Console.WriteLine($"{array[i]}]");
        else Console.Write($"{array[i]}, ");
    }
}
#endregion