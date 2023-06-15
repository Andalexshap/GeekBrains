// Программа принимает на вход 3 числа и выдаёт максимальное из этих чисел
Console.WriteLine("Нахождение максимального из трех чисел.");

Console.WriteLine("Сравнение 2х чисел");

int firstValue, secondValue, thirdValue;

while (true)
{
    Console.WriteLine("Введите первое число: ");

    bool firstResult = int.TryParse(Console.ReadLine(), out firstValue);

    if (firstResult)
    {
        Console.WriteLine("Введите второе число: ");
        bool secondResult = int.TryParse(Console.ReadLine(), out secondValue);

        if (secondResult)
        {
            Console.WriteLine("Введите третье число: ");
            bool thirdResult = int.TryParse(Console.ReadLine(), out thirdValue);
            
            if (thirdResult)break;      
        }        
    }

    Console.WriteLine("Введенные данные не являются числом! Давайте еще раз!");
    continue;
}

int max = firstValue;
if (max < secondValue) max = secondValue;
if (max <thirdValue) max = thirdValue;

Console.WriteLine($"Максимальное из трех чисел: {max}");