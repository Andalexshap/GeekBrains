/* Задача 10: Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает вторую цифру этого числа.
456 -> 5
782 -> 8
918 -> 1*/

Console.WriteLine("Программа, принимает на вход трёхзначное число и на выходе показывает вторую цифру этого числа");

while (true)
{
    Console.Write("Введите трехзначное число: ");

    int number;
    string str = Console.ReadLine()!;
    str = string.IsNullOrEmpty(str) ? "100" : str;

    if (str.Length != 3)
    {
        Console.WriteLine("Необходимо ввести ТРЕХЗНАЧНОЕ число! Давате сначала!");
        Thread.Sleep(2000);
        continue;
    }

    bool result = int.TryParse(str, out number);

    if (!result)
    {
        Console.WriteLine("Необходимо ввести число. Давайте сначала!");
        continue;
    }
    else
    {
        Console.WriteLine($"Вторая цифра числа {number} равна {number / 10 % 10}");
        break;
    }
}


