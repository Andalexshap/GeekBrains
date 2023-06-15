/*
Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
1, 7 -> такого элемента в массиве нет
*/

Console.WriteLine("Программа для поиска элемента в массиве размера m*n.");
Console.WriteLine("Созданный массив:");

int[,] matrix = CreateMatrixRndInt();
PrintMatrix(matrix);

Console.WriteLine("Задайте номер элемента (строка, столбец).");

int rows = InputNumber("Введите строку: ");
int column = InputNumber("Введите столбец: ");

CheckElementInMatrix(matrix, rows, column);





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

int[,] CreateMatrixRndInt()
{
    Random random = new Random();
    int[,] matrix = new int[random.Next(1, 10), random.Next(1, 10)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = random.Next(-100, 100);
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
            if (matrix[i, j] > 0) Console.Write($" {matrix[i, j]} ");
            else Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

void CheckElementInMatrix(int[,] matrix, int rows, int colum)
{
    if (matrix.GetLength(0) < rows || matrix.GetLength(1) < colum)
    {
        Console.WriteLine($"Элемента с индексом [{rows},{colum}] НЕТ!");
    }
    else
    {
        Console.WriteLine($"Значение элемента с индексом [{rows},{colum}] равно: {matrix[rows, colum]}");
    }

}

#endregion