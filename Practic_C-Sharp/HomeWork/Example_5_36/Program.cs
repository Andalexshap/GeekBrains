/*
Задача 36: Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.
[3, 7, 23, 12] -> 19
[-4, -6, 89, 6] -> 0
*/

Console.WriteLine("Программа, для создание рандомно заполененого массива и суммы элементов на нечетных позициях");

var size = InputNumber();
var array = CreateArrayRndInt(size);

PrintArray(array, "Созданный массив");

var result = SumElementsWithOddIndex(array);

Console.WriteLine($"Сумма элементов, стоящих на нечётных позициях, равна: {result}");



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
        array[i] = rnd.Next(-100, 100);
    }

    return array;
}

void PrintArray(int[] array, string massege)
{
    Console.Write($"{massege}: [");

    for (int i = 0; i < array.Length; i++)
    {
        if (i == array.Length - 1) Console.WriteLine($"{array[i]}]");
        else Console.Write($"{array[i]}, ");
    }
}
int SumElementsWithOddIndex(int[] array)
{
    int result = 0;
    for(int i = 0; i < array.Length; i++)
    {
        if(i%2 == 1) result += array[i];
    }

    return result;
}
#endregion