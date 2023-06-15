/*
Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
[3.5, 7.1, 22.9, 2.3, 78.5] -> 76.2
*/

Console.WriteLine("Программа, для создание рандомно заполененого массива вещественных чисел и вывод разници между максимальным и минимальным элементов массива.");

var size = InputNumber();
var array = CreateArrayRndDouble(size);

PrintArray(array, "Созданный массив");

var result = MaxElement(array) - MinElement(array);

Console.WriteLine($"Разница между максимальным и минимальным элементов массива, равна: {result}");



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

double[] CreateArrayRndDouble(int size)
{
    double[] array = new double[size];
    var rnd = new Random();

    for (int i = 0; i < size; i++)
    {
        array[i] = Math.Round(rnd.NextDouble() * 100, 2);
    }

    return array;
}

void PrintArray(double[] array, string massege)
{
    Console.Write($"{massege}: [");

    for (int i = 0; i < array.Length; i++)
    {
        if (i == array.Length - 1) Console.WriteLine($"{array[i]}]");
        else Console.Write($"{array[i]}, ");
    }
}

double MaxElement(double[] array)
{
    double max = array[0];
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] > max) max = array[i];
    }
    return max;
}

double MinElement(double[] array)
{
    double min = array[0];
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] < min) min = array[i];
    }
    return min;
}
#endregion