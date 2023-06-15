/*
Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9
*/

Console.WriteLine("Программа выведет двумерный массив размера m*n.");
Console.WriteLine("Вам необходимо задать колличество строк(m) и строк (m)");

int rows = InputNumber("Введите колличество строк(m): ");
int column = InputNumber("Введите колличество столбцов(n): ");

double[,] matrix = CreateMatrixRndDouble(rows, column);
PrintMatrix(matrix);



#region Methods
int InputNumber(string message)
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

double[,] CreateMatrixRndDouble(int rows, int column)
{
    double[,] matrix = new double[rows, column];
    Random random = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = Math.Round(random.NextDouble() * random.Next(-10, 10), 2);
        }
    }

    return matrix;
}

void PrintMatrix(double[,] matrix)
{
for (int i = 0; i < matrix.GetLength(0); i++)
{
    Console.Write("|");
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i,j], 5} |");
        else Console.Write($"{matrix[i,j], 5}");
    }
    Console.WriteLine(" |");
}
}

#endregion