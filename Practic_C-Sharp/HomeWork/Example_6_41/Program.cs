/*
Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
0, 7, 8, -2, -2 -> 2
1, -7, 567, 89, 223-> 3
*/

Console.WriteLine("Программа покажет сколько чисел введенных Вами являются положительными");

while (true)
{
    Console.WriteLine("Введите ряд чисел разделенных пробелом:");

    string numbers = Console.ReadLine()!;

    if (string.IsNullOrEmpty(numbers))
    {
        Console.WriteLine("Вы не ввели ни одного числа! Давайте сначала.");
        continue;
    }

    string[] stringNumbersArray = ConvertStringNumbersToArraySubstring(numbers);
    int[] intNumbersArray = new int[stringNumbersArray.Length];

    try
    {
        intNumbersArray = ConvertArrayStringToArrayInt(stringNumbersArray);
    }
    catch
    {
        Console.WriteLine("Проверьте правильность ввода и повторите попытку");
        continue;
    }

    int[] positiveNumbers = PositivNumbers(intNumbersArray);
    PrintResult(positiveNumbers);

    break;
}

#region Methods
string[] ConvertStringNumbersToArraySubstring(string numbers)
{
    string[] stringNumbersArray = numbers.Split(' ');
    return stringNumbersArray;
}

int[] ConvertArrayStringToArrayInt(string[] numbers)
{
    int[] intNumbersArray = new int[numbers.Length];

    for (int i = 0; i < numbers.Length; i++)
    {
        intNumbersArray[i] = Int32.Parse(numbers[i]);
    }
    return intNumbersArray;
}

int[] PositivNumbers(int[] numbers)
{
    List<int> PositivNumbers = new List<int>();

    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] > 0) PositivNumbers.Add(numbers[i]);
    }

    return PositivNumbers.ToArray();
}

void PrintResult(int[] numbers)
{
    if (numbers.Length != 0)
    {
        Console.WriteLine($"Колличество положительных чисел: {numbers.Length}");
        Console.Write("Положительные числа: ");

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"{numbers[i]} ");
        }
    }
    else Console.WriteLine($"Колличество положительных чисел: {numbers.Length}");
}

#endregion