/* Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
14212 -> нет
12821 -> да
23432 -> да*/

Console.WriteLine("Проверка числа на полиндром");

while (true)
{
    Console.WriteLine("Введите любое число: ");

    int number;

    string str = Console.ReadLine()!;
    str = !string.IsNullOrEmpty(str) ? str : "0";

    var result = int.TryParse(str, out number);

    if (!result)
    {
        Console.WriteLine("Необходимо ввести число. Давайте сначала!");
        Thread.Sleep(2000);
        continue;
    }

    Console.WriteLine(ReverseNumber(number) == number ? $"Число {number} - является полиндромом" : $"Число {number} - не является полиндромом");
    break;
}

int ReverseNumber(int number)
{
    int reverse = 0;
    while (number > 0)
    {
        reverse = reverse * 10 + number % 10;
        number /= 10;
    }
    return reverse;
}