/*
Задача 25: Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
3, 5 -> 243 (3⁵)
2, 4 -> 16
*/

Console.WriteLine("Программа для вычесления степени числа");

int[] array = InputNumber();
int result = DegreeOfNumber(array);
Console.WriteLine($"Число {array[0]} в степени {array[1]}, равно {result}.");


int[] InputNumber()
{
    while (true)
    {
        Console.WriteLine("Введите число: ");
        int number = 0;
        bool firstResult = int.TryParse(Console.ReadLine(), out number);

        if (firstResult)
        {
            Console.WriteLine("Введите степень (положительное целое число): ");
            int degree = 0;
            bool secondResult = int.TryParse(Console.ReadLine(), out degree);

            if (!secondResult)
            {
                Console.WriteLine("Введены некоректные данные. Введите ЧИСЛО еще раз!");
                Thread.Sleep(2000);
                continue;
            }

            int[] array = { number, Math.Abs(degree) };
            return array;
        }
        else
        {
            Console.WriteLine("Введены некоректные данные. Введите ЧИСЛО еще раз!");
            Thread.Sleep(2000);
            continue;
        }
    }

}

int DegreeOfNumber(int[] array)
{
    int result = array[0];

    for (int i = 1; i < array[1]; i++)
    {
        result *= array[0];
    }

    return result;
}