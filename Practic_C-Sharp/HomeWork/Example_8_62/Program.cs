/*Задача 62.Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

Console.WriteLine("Программа, заполнит спирально массив 4 на 4.");

int n = 4;
int[,] matrix = CreateArrayInt(n, n);
PrintArray(matrix);

#region Methods

int[,] CreateArrayInt(int rows, int column)
{
    int[,] matrix = new int[n, n];

    int maxRows = matrix.GetLength(0);
    int maxColumns = matrix.GetLength(1);

    int maxCount = maxRows * maxColumns;
    int i = 0;
    int j = 0;

    for (int temp = 1; temp <= maxCount; temp++)
    {
        matrix[i, j] = temp;
        if (i <= j + 1 && i + j < maxColumns - 1)
            j++;
        else if (i < j && i + j >= maxRows - 1)
            i++;
        else if (i >= j && i + j > maxColumns - 1)
            j--;
        else
            i--;
    }

    return matrix;
}

void PrintArray(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] / 10 <= 0)
                Console.Write($"0{matrix[i, j]} ");

            else Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

#endregion