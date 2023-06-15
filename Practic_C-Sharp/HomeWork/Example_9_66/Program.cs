/*Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
M = 1; N = 15 -> 120
M = 4; N = 8. -> 30
*/
Console.WriteLine("Программа, которая найдёт сумму натуральных элементов в промежутке от M до N");

int numM = InputNumber("Введите число M: ");
int numN = InputNumber("Введите число N: ");
Console.WriteLine(SumNaturalNumbers(numM, numN));


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

int SumNaturalNumbers(int numM, int numN)
{
    if (numN > numM) return numM += SumNaturalNumbers(numM + 1, numN);
    else if (numN < numM) return numM += SumNaturalNumbers(numM - 1, numN);
    return numM;
}
#endregion