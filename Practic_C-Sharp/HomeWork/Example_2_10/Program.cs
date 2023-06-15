/* Задача 10: Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает вторую цифру этого числа.
456 -> 5
782 -> 8
918 -> 1
*/
Console.WriteLine("Определение десятичной цифры в трехзначном числе");

int value;

while (true)
{
    Console.WriteLine("Введите любое 3-х значное число число:");
    bool result = int.TryParse(Console.ReadLine(), out value);

    if (result & value > 99 & value < 999)break;     

    if(!result)
    {
        Console.WriteLine("Введенные данные не являются числом! Давайте еще раз!");
        continue; 
    }

    if(value < 99 & value > 999)
    {
        Console.WriteLine("Введенное число не входит в диапазон от 99 до 999! Давайте еще раз!");
        continue; 
    }    
}

int decade = value/10%10;

Console.WriteLine($"Количество десятков в числе {value} равно {decade}.");