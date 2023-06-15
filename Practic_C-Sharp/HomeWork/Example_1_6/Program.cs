// Проверка числа на четность
Console.WriteLine("Провека числа на четность.");

int value;

while (true)
{
    Console.WriteLine("Введите любое целое число:");
    bool result = int.TryParse(Console.ReadLine(), out value);

    if (result)break;     

    Console.WriteLine("Введенные данные не являются числом, либо число не целое! Давайте еще раз!");
    continue;
}

if(value%2==0) 
{
    Console.WriteLine($"Число: {value} является четным!");
}
else
{
    Console.WriteLine($"Число: {value} является нечетным!");
}