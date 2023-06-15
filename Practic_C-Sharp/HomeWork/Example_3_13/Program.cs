/*Задача 13: Напишите программу, которая выводит третью цифру заданного числа или сообщает, что третьей цифры нет.
645 -> 5
78 -> третьей цифры нет
32679 -> 6
*/

Console.WriteLine("Определение третьей цифры в числе");
Console.Write("Введите любое число: ");

string value = Console.ReadLine() ?? "0";

if (value.Length < 3)
{
    Console.WriteLine("Третьей цифры нет!");
}
else
{
    int number;
    bool result = int.TryParse(value, out number);

    if (!result)
    {
        Console.Write("Введенные данные не являются числом!");
    }
    else
    {
        while (number > 999)
        {
            number = number / 10;
        }

        int outResult = number % 10;
        Console.WriteLine($"Третья цифра: {outResult}");
    }
}