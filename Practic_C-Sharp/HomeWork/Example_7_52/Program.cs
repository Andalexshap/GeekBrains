/*
Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*/

Console.WriteLine("Программа для среднего арифметического по столбцам в массиве размера m*n.");
Console.WriteLine("Созданный массив:");

int[,] matrix = CreateMatrixRndInt();
PrintMatrix(matrix);

Console.WriteLine("Среднее арифметическое: ");
AverageColums(matrix);


#region Methods

int[,] CreateMatrixRndInt()
{
    Random random = new Random();
    int[,] matrix = new int[random.Next(3, 10), random.Next(1, 10)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = random.Next(1, 100);
        }
    }

    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] > 0) Console.Write($"{matrix[i, j]} ");
            else Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

void AverageColums(int[,] matrix)
{
    double avarage = 0;
    for (int colum = 0; colum < matrix.GetLength(1); colum++)
    {
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            avarage += matrix[rows, colum];
        }
        Console.Write($"{avarage / matrix.GetLength(0)} ");
        avarage = 0;
    }
}

#endregion