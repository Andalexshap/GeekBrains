/*Задача 64: Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от N до 1. Выполнить с помощью рекурсии.
N = 5 -> "5, 4, 3, 2, 1"
N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"
*/
Console.WriteLine("Программа, которая выведет все натуральные числа в промежутке от N до 1");

int numN = InputNumber("Введите число N: ");
NaturalNumber(numN);

#region Methods

int InputNumber(string message)
{
    while (true)
    {
        Console.Write(message);
        bool result = int.TryParse(Console.ReadLine(), out int value);

        if (!result)
        {
            Console.WriteLine($"Введены некоректные данные. {message} еще раз!");
            Thread.Sleep(1500);
            Console.Clear();

            continue;
        }

        return value;
    }
}

void NaturalNumber(int num)
{
    if (num == 0) return;
    Console.Write($"{num} ");
    NaturalNumber(num - 1);
}
#endregion