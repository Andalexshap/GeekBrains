/*
Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
*/

Console.WriteLine("Программа найдёт точку пересечения двух прямых, заданных уравнениями \ny = k1 * x + b1, \ny = k2 * x + b2;");
Console.WriteLine("Вам необходимо задать числа k1, b1, k2, b2");

double[] variables = {
    InputNumber("Введите число k1: "),
    InputNumber("Введите число b1: "),
    InputNumber("Введите число k2: "),
    InputNumber("Введите число b2: ") };

if (variables[0] == variables[2] && variables[1] == variables[3])
{
    Console.WriteLine("Прямые совпадают!");
}
else if (variables[0] == variables[2])
{
    Console.WriteLine("Прямые параллельны!");
}
else
{
    double[] point = IntersectionPointOfLines(variables);

    Console.WriteLine($"Точка пересечения двух прямых: ({point[0]} ; {point[1]})");
}

#region Methods
double InputNumber(string message)
{
    while (true)
    {
        Console.Write(message);
        bool result = double.TryParse(Console.ReadLine(), out double number);

        if (!result)
        {
            Console.WriteLine($"Введены некоректные данные. {message} еще раз!");
            Thread.Sleep(1500);

            continue;
        }

        return number;
    }
}

double[] IntersectionPointOfLines(double[] variables)
{
    double[] point = new double[2];

    point[0] = (variables[3] - variables[1]) / (variables[0] - variables[2]);
    point[1] = variables[0] * point[0] + variables[1];

    return point;
}

#endregion