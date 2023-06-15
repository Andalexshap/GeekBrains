string[] days = {"Понедельник", "Пторник", "Среда","Четверг", "Пятница","Суббота","Воскресенье"};
int numberOfDay;

Console.WriteLine("Введите номер дня недели от 1 до 7:");

bool result = int.TryParse(Console.ReadLine(), out numberOfDay);

if (!result)
{
    Console.WriteLine("Введенные данные не являются числом");
}
else if(0 < numberOfDay & numberOfDay <= 7)
{
Console.WriteLine($"Цифре {numberOfDay} соответсвует {days[numberOfDay-1]}");
}
else
{
Console.WriteLine($"Введеное число не попадает в диапазон [1,7]");
}