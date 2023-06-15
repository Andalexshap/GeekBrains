/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

Console.WriteLine("Программа,найдет строку с наименьшей суммой элементов.");
Console.WriteLine($"\nВведите размер массива m x n , максимальное и минимальное значение:");

int m = InputNumber("Введите m: ");
int n = InputNumber("Введите n: ");

if (m == 0 || n == 0)
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

Console.WriteLine("Созданный массив: ");
int[,] matrix = CreateMatrixInt(m, n, minValue, maxValue);
PrintMatrix(matrix);

(int, int) minSum = MinSumRowElements(matrix);

Console.WriteLine($"Минимальная сумма элементов Найдена в {minSum.Item1} строке, \nИ равна {minSum.Item2}");


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
            Console.Write($"{matrix[i, j],5}");
        }
        Console.WriteLine();
    }
}

(int, int) MinSumRowElements(int[,] matrix)
{
    int minSumRows = 0;
    int sum = int.MaxValue;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {

        int temp = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            temp += matrix[i, j];
        }

        if (temp < sum)
        {
            sum = temp;
            minSumRows = i;
        }
    }

    return (minSumRows, sum);
}

#endregion