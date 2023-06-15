/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

Console.WriteLine("Программа, найдет произведение двух матриц.");
Console.WriteLine("Колличество строк первой матрицы должно быть равно количеству столбцов второй матрицы");
Console.WriteLine($"Введите размеры матриц (m x n):");
int firstMatrixRows = InputNumber("Введите колличество строк 1-й матрицы(m1): ");
int firstMatrixColums = InputNumber("Введите колличество столбцов 1-й матрицы (и строк 2-й)(n1 = m2): ");
int secondMatrixColums = InputNumber("Введите колличество столбцов 2-й матрицы (n2): ");

if (firstMatrixRows == 0 || firstMatrixColums == 0 || secondMatrixColums == 0)
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

Console.WriteLine("Первый массив: ");
int[,] firstMatrix = CreateMatrixInt(firstMatrixRows, firstMatrixColums, minValue, maxValue);
PrintMatrix(firstMatrix);

Console.WriteLine("Второй массив: ");
int[,] secondMatrix = CreateMatrixInt(firstMatrixColums, secondMatrixColums, minValue, maxValue);
PrintMatrix(secondMatrix);

Console.WriteLine("Результат перемножения 2х массивов");
int[,] multiplyMatrix = MultiplyMatrix(firstMatrix, secondMatrix);
PrintMatrix(multiplyMatrix);



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

int[,] CreateMatrixInt(int rows, int colums, int minValue, int maxValue)
{
    Random random = new Random();
    int[,] matrix = new int[rows, colums];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = random.Next(minValue, maxValue);
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
            Console.Write($"{matrix[i, j],10}");
        }
        Console.WriteLine();
    }
}

int[,] MultiplyMatrix(int[,] firstMartrix, int[,] secomdMartrix)
{
    int[,] multiplyMatrix = new int[firstMartrix.GetLength(0), secomdMartrix.GetLength(1)];
    for (int i = 0; i < multiplyMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < multiplyMatrix.GetLength(1); j++)
        {
            int multiply = 0;
            for (int k = 0; k < firstMartrix.GetLength(1); k++)
            {
                multiply += firstMartrix[i, k] * secomdMartrix[k, j];
            }
            multiplyMatrix[i, j] = multiply;
        }
    }
    return multiplyMatrix;
}

#endregion