Console.WriteLine("Программа примет данные и выдаст в резальтате только те, которые соответствуют условию.");

int number = InputNumber("Введите количество строк, которое необходимо принять: ");

string[] inputData = InputStringToArray(number);

Console.WriteLine("Принятые данные:");
PrintArray(inputData);

int maxLenght = 3;
string[] selectingInputDataByLenght = SelectingElementsByLength(inputData, maxLenght);

Console.WriteLine($"Элементы, длина которых меньше или равна {maxLenght} символа:");
PrintArray(selectingInputDataByLenght);


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

string[] InputStringToArray(int size)
{
    string[] inputData = new string[size];
    for (int i = 0; i < size; i++)
    {
        Console.Write($"Введите {i + 1}й элемент: ");
        inputData[i] = Console.ReadLine() ?? "null";
    }

    Console.WriteLine();

    return inputData;
}

string[] SelectingElementsByLength(string[] array, int lenght)
{
    string[] selectingArray = array.Where(x => x.Length <= lenght).ToArray();
    return selectingArray;
}

void PrintArray(string[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (i == array.Length - 1) Console.WriteLine($"{array[i]}");
        else Console.Write($"{array[i]}, ");
    }
    Console.WriteLine();
}
#endregion