// Программа принимает на вход число N и на выходе показывает все четные числа от 1 до N
Console.WriteLine("Мы покажем Вам все четные числа от 1 до введенного числа");

int value;

while (true)
{
    Console.WriteLine("Введите любое целое число, больше нуля:");
    bool result = int.TryParse(Console.ReadLine(), out value);

    if (result)break;     

    Console.WriteLine("Введенные данные не являются числом, либо число не целое! Давайте еще раз!");
    continue;
}

if(value ==1) 
{
    Console.WriteLine($"Введенное число меньше первого положительного четного числа");
}
else
{
    int count = 2;
    while(count <= value)
    {
        if(count == value) Console.Write(count);
        else Console.Write($"{count}, ");
        count +=2;
    }
}