/*
 * Задача 33: Задайте массив.Напишите программу, которая определяет, присутствует ли заданное число в массиве.
4; массив[6, 7, 19, 345, 3]->нет
3; массив[6, 7, 19, 345, 3]->да
*/

Console.WriteLine("Программа для поиска заданного числа в массиве");

Console.WriteLine("Задайте размер массива:");
int size = int.Parse(Console.ReadLine()!);

if (size <= 0) Console.WriteLine("Размер массива не может быть отрицательным или равен нулю");

int[] array = CreateArrayRndInt(size);
PrintArray(array, "Полученный массив");

Console.WriteLine("Введите искомое число:");
int number = int.Parse(Console.ReadLine()!);
bool request = FindNumber(array, number);

if(request) Console.WriteLine("Заданное число присутсвует в массиве.");
else Console.WriteLine("Заданное число отсутствует в массиве.");




#region Methods
void PrintArray(int[] array, string message)
{
    Console.Write($"{message}: [");

    for (int i = 0; i < array.Length; i++)
    {
        if (i == array.Length - 1) Console.WriteLine($"{array[i]}]");
        else Console.Write($"{array[i]}, ");
    }
}

int[] CreateArrayRndInt(int size)
{
    int[] array = new int[size];
    var rnd = new Random();

    for (int i = 0; i < size; i++)
    {
        array[i] = rnd.Next(1, 1000);
    }

    return array;
}

bool FindNumber(int[] array, int number)
{
    bool result = false;

    for (int i = 0; i < array.Length; i++)
    {
        if(array[i] == number) result = true;
    }

    return result;
}
#endregion
