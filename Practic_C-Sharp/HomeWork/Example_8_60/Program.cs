
/*Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Например, задан массив размером 2 x 2 x 2.
Результат:
66(0, 0, 0) 27(0, 0, 1) 25(0, 1, 0) 90(0, 1, 1)
34(1, 0, 0) 26(1, 0, 1) 41(1, 1, 0) 55(1, 1, 1)
*/

Console.WriteLine("Программа, будет построчно выводить массив, добавляя индексы каждого элемента.");
Console.WriteLine($"Введите размеры трехмерного массива (X x Y x Z):");
int x = InputNumber("Введите X: ");
int y = InputNumber("Введите Y: ");
int z = InputNumber("Введите Z: ");

if (x == 0 || y == 0 || z == 0)
{
    Console.WriteLine("Размер массива не может быть равен 0");
    Thread.Sleep(1500);
    Environment.Exit(0);
}

int minValue = InputNumber("Введите минимальное значаение: ");
int maxValue = InputNumber("Введите максимальное значаение: ");

if (minValue > maxValue)
{
    Console.WriteLine("Минимальное значение должно быть меньше максимального");
    Thread.Sleep(1500);
    Environment.Exit(0);
}

Console.WriteLine("Созданный массив");
int[,,] firstMatrix = Create3DArrayInt(x, y, z, minValue, maxValue);
PrintArray3D(firstMatrix);


#region Methods
int InputNumber(string message, bool number = false)
{
    while (true)
    {
        Console.Write(message);
        bool result = int.TryParse(Console.ReadLine(), out int value);

        if (!result)
        {
            Console.WriteLine($"Введены некоректные данные. {message} еще раз!");
            Thread.Sleep(1500);
            Console.Clear();

            continue;
        }

        return value;
    }
}

int[,,] Create3DArrayInt(int x, int y, int z, int minValue, int maxValue)
{
    Random random = new Random();
    int[,,] matrix = new int[x, y, z];

    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            for (int k = 0; k < z; k++)
            {
                matrix[i, j, k] = random.Next(minValue, maxValue);
            }
        }
    }

    return matrix;
}

void PrintArray3D(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                Console.Write($" {matrix[i, j, k]} ({i}, {j}, {k}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

#endregion