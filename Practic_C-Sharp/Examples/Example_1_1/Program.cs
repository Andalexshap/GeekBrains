Console.WriteLine("Давайте проверим, явялестся ли первое число квадратом второго:");
Console.WriteLine("Введите первое число");

int firstValue, secondValue;
bool result = int.TryParse(Console.ReadLine(), out firstValue);

if (!result)
{
    Console.WriteLine("Введенные данные не являются числом");
}

Console.WriteLine("Введите второе число");

result = int.TryParse(Console.ReadLine(), out secondValue);

if (!result)
{
    Console.WriteLine("Введенные данные не являются числом");
}
if(secondValue*secondValue==firstValue)
{
    Console.WriteLine($"Число {secondValue} является квадратом {firstValue}");
}
else
{
Console.WriteLine($"Число {secondValue} не является квадратом {firstValue}");
}
