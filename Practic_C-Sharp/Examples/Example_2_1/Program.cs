// Дано число. Проверить кратно ли оно 7 и 23

Console.WriteLine("Проверка числа на кратность 7 и 23");
Console.WriteLine("Введите число:");

int number;

bool result = int.TryParse(Console.ReadLine(), out number);

if(!result)
{
Console.WriteLine("Введенные данные не являются числом");
}

if (number % 7 == 0 && number % 23 == 0)
{
    Console.WriteLine($"Число {number} кратно 7 и 23");
}
else
{
Console.WriteLine($"Число {number} не кратно 7 и 23");
}

var num = 5&4;
Console.WriteLine(num);