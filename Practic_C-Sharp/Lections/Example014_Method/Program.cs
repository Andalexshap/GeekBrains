// See https://aka.ms/new-console-template for more information

void Method()
{
    Console.WriteLine("Автор ....");
}

Method();

void SecondMethod(string msg)
{
    Console.WriteLine(msg);
}

SecondMethod("Текст сообщения");

void SecondPointOneMethod(string msg, int count)
{
    int i = 0;
    while (i < count)
    {
        Console.WriteLine(msg);
        i++;
    }
}

SecondPointOneMethod(msg: "Текст сообщения", count: 4);

int ThirdMethod()
{
    return DateTime.Now.Year;
}

int year = ThirdMethod();
Console.WriteLine(year);

string FourMethod(int count, string c)
{
    string result = string.Empty;
    //while (i < count)
    //{
    //    result += c;
    //    i++;
    //}
    //for (int i = 0; i < count; i++)
    //{
    //        result += c;
    //        i++;
    //}
    for (int i = 2; i <= 10; i++)
    {
        for (int j = 2; j <= 10; j++)
        {
            Console.WriteLine($"{i} * {j} = {i * j}");
        }
        Console.WriteLine();
    }
    return result;
}

string res = FourMethod(10, "sadfa");
Console.WriteLine(res);

string Replase(string text, char oldValue, char newValue)
{
    string result = String.Empty;

    int length = text.Length;
    for (int i = 0; i < length; i++)
    {
        if (text[i] == oldValue) result += $"{newValue}";
        else result += $"{text[i]}";
    }

    return result;
}

string text = "dsggsgs sdgsdgsdgewdfgvc sdgsdg sdgasf as gsdsd gfas gas gas g g gsa ga ga sdg";
string newText = Replase(text, ' ', '|');
Console.WriteLine(newText);

int[] array = { 1, 6, 8, 4, 5, 9, 7, 3, 2 };

void PrintArray(int[] array)
{
    int count = array.Length;

    for (int i = 0; i < count; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();
}

void SelectionSortMinMax(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int minPosition = i;

        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[j] < array[minPosition]) minPosition = j;
        }

        int temporary = array[i];
        array[i] = array[minPosition];
        array[minPosition] = temporary;
    }
}

void SelectionSortMaxMin(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int minPosition = i;

        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[j] > array[minPosition]) minPosition = j;
        }

        int temporary = array[i];
        array[i] = array[minPosition];
        array[minPosition] = temporary;
    }
}

PrintArray(array);
SelectionSortMinMax(array);
PrintArray(array);
SelectionSortMaxMin(array);
PrintArray(array);