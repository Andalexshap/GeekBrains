// Программа, которая на вход принимает 2 числа и выдаёт, какое число больше, а какое меньше.
Console.WriteLine("Сравнение 2х чисел");

int firstValue, secondValue;

while(true)
{
    Console.WriteLine("Введите первое число: ");

    bool firstResult = int.TryParse(Console.ReadLine(), out firstValue);

    if (firstResult)
    {
        Console.WriteLine("Введите второе число: ");
        bool secondResult = int.TryParse(Console.ReadLine(), out secondValue);

        if (secondResult) break;        
    }
    
    Console.WriteLine("Введенные данные не являются числом! Давайте еще раз!");
    continue;
}

if(firstValue>secondValue) Console.WriteLine($"Число {firstValue} больше, чем {secondValue}");
else if (firstValue<secondValue) Console.WriteLine($"Число {secondValue} больше, чем {firstValue}");
else Console.WriteLine($"Числа равны!");
