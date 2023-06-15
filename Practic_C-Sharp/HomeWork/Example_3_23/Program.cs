/*Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
3 -> 1, 8, 27
5 -> 1, 8, 27, 64, 125 */

while (true)
{
    Message();

    int value;
    string str = Console.ReadLine()!;
    str = string.IsNullOrEmpty(str) ? "2" : str;
    var result = int.TryParse(str, out value);

    if (!result)
    {
        Console.WriteLine("Введены некоректные данные. Введите ЧИСЛО еще раз!");
        Thread.Sleep(2000);
        continue;
    }

    if (value < 0) value = -value;

    if (value < 2) value = 2;

    Console.Write($"Кубы числа \"{value}\": ");

    for (int i = 1; i <= value; i++)
    {

        if (i == value) Console.Write(Math.Pow(i, 3));
        else Console.Write(Math.Pow(i, 3) + ", ");
    }
    value.ToString();
    break;
}

void Message()
{
    Console.Clear();
    Console.WriteLine("Вывод последовательности кубов чисел от 1 до N");
    Console.WriteLine();
    Console.WriteLine("Отрицательное число будет преобразованно в положительное.");
    Console.WriteLine("При отсутсвии данных или если число меньше \"2\", будет использованно число \"2\"");
    Console.WriteLine("Введите любое число больше 1: ");
}