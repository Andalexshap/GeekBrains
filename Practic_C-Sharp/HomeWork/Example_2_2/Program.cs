// 2.По двум заданным числам проверять является ли одно квадратом другого
Console.WriteLine("Проверка является ли одно число квадратом другого");

while(true)
{
    Console.WriteLine("Введите первое число: ");
    int firstValue;
    bool firstResult = int.TryParse(Console.ReadLine() ?? "0", out firstValue);

    Console.WriteLine("Введите второе число: ");
    int secondValue;
    bool secondResult = int.TryParse(Console.ReadLine() ?? "0", out secondValue);

    if (!firstResult || !secondResult)
    {
        Console.WriteLine("Введенные данные не являются числом. Введите числа еще раз");
        continue;
    }
    else
    {
        if(firstValue/secondValue == secondValue)
        {
            Console.WriteLine($"Число {firstValue} является квадратом {secondValue}");
        }
        else if(secondValue/firstValue == firstValue)
        {
            Console.WriteLine($"Число {secondValue} является квадратом {firstValue}");
        }
        else
        {
            Console.WriteLine($"Число {firstValue} не является квадратом {secondValue} как и число {secondValue} не является квадратом {firstValue}");
        }
        break;
    }
}