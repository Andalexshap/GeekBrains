// 1.Дано число обозначающее день недели. Выяснить является номер дня недели выходным
Console.WriteLine("Является номер дня недели выходным");
Console.WriteLine("Введите число обозначающее день недели от 1 до 7:");

int number;
bool result = int.TryParse(Console.ReadLine() ?? "0", out number);

if(!result) 
    Console.WriteLine("Введенные данные не являются числом");
else
{
    if (number < 1 || number > 7)
        Console.WriteLine($"Введенное число {number} не входит в давппазон [1;7]");
    else if(number == 6 || number ==7)
        Console.WriteLine($"Введенное число {number} соответсвует выходному дню");
    else
        Console.WriteLine($"Введенное число {number} соответсвует рабочему дню");
}