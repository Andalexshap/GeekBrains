/*
Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
452 -> 11
82 -> 10
9012 -> 12
*/
Console.WriteLine("Программа для вычесления суммы чисел числа");
int value = InputNumber();
Console.WriteLine($"Сумма цифр в числе {value} равна {SumOfNumber(value)}");

int InputNumber()
{
    int count = 0;
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Введите число: ");
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

        return number;
    }
}

int SumOfNumber(int number)
{
    int result = 0;
    while (number > 0)
    {
        result += number % 10;
        number /= 10;
    }
    return result;
}