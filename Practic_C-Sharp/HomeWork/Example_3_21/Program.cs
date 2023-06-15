/* Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
A (3,6,8); B (2,1,-7), -> 15.84
A (7,-5, 0); B (1,-1,9) -> 11.53*/

Console.WriteLine("Нахождение расстояния между точками в 3D пространстве");

while (true)
{
    int x1, y1, z1, x2, y2, z2;
    int result;

    Console.Write("Введиту координаты точки А в формате XYZ без пробелов и разделителей: ");
    string pointA = Console.ReadLine() ?? "000";
    bool result_x1 = int.TryParse(pointA, out result);

    Console.Write("Введиту координаты точки B в формате XYZ без пробелов и разделителей: ");
    string pointB = Console.ReadLine() ?? "000";
    bool result_y1 = int.TryParse(pointB, out result);

    if (!result_x1 || !result_y1)
    {
        Console.WriteLine("Необходимо вводить числа. Давайте сначала!");
        continue;
    }
    else
    {
        x1 = Convert.ToInt32(pointA[0]);
        y1 = Convert.ToInt32(pointA[1]);
        z1 = Convert.ToInt32(pointA[2]);
        x2 = Convert.ToInt32(pointB[0]);
        y2 = Convert.ToInt32(pointB[1]);
        z2 = Convert.ToInt32(pointB[2]);

        double resultForPrint = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) + Math.Pow(z1 - z2, 2));

        Console.WriteLine($"Расстояние A({pointA[0]},{pointA[1]},{pointA[2]}) И В({pointB[0]},{pointB[1]},{pointB[2]}) равно: {resultForPrint}");
        break;
    }
}
