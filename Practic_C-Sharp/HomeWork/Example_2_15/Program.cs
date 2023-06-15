/*Задача 15: Напишите программу, которая принимает на вход цифру, обозначающую день недели, и проверяет, является ли этот день выходным.
6 -> да
7 -> да
1 -> нет
*/

Console.WriteLine("Введите цифру от 1 - 7, соответсвующую дню недели");

int number = 1;
string value = Console.ReadLine()!;
value = string.IsNullOrEmpty(value) ? "1" : value;
bool result = int.TryParse(value, out number);

if(result)
{
    if (number == 6 || number == 7)
    {
        Console.WriteLine("Да.Выходной!");
    }
    else if(number < 1 || number > 7) 
    {
        Console.WriteLine("Число не соответсвует дню недели!");
    }
    else
    {
        Console.WriteLine("Нет. Рабочий день!");
    }
}