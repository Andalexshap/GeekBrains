// Найти расстояние между точками в пространстве 2D/3D
Console.WriteLine("Нахождение расстояния между точками в 2D и 3D пространстве");

while (true)
{
    double x1, y1, z1, x2, y2, z2;

    Console.Write("Введиту координату Х первой точки: ");
    bool result_x1 = double.TryParse(Console.ReadLine() ?? "0", out x1);
    
    Console.Write("Введиту координату Y первой точки: ");
    bool result_y1 = double.TryParse(Console.ReadLine() ?? "0", out y1);

    Console.Write("Введиту координату Z первой точки: ");
    bool result_z1 = double.TryParse(Console.ReadLine() ?? "0", out z1);
    
    Console.Write("Введиту координату X второй точки: ");
    bool result_x2 = double.TryParse(Console.ReadLine() ?? "0", out x2);

    Console.Write("Введиту координату Y второй точки: ");
    bool result_y2 = double.TryParse(Console.ReadLine() ?? "0", out y2);

    Console.Write("Введиту координату Z второй точки: ");
    bool result_z2 = double.TryParse(Console.ReadLine() ?? "0", out z2);

    if (!result_x1 || !result_y1 || !result_z1 || !result_x2 || !result_y2 || !result_z2)
    {
        Console.WriteLine("Необходимо вводить числа. Давайте сначала!");
        continue;
    }
    else
    {
        double result = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) + Math.Pow(z1 - z2, 2));
        Console.WriteLine($"Расстояние между точками равно: {result}");
        break;
    }
}