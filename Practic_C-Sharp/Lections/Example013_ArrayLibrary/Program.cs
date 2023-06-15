int[] array = new int[10];

System.Console.WriteLine("FillArray");
FillArray(array);
System.Console.WriteLine("PrintArray");
PrintArray(array);
System.Console.WriteLine("IndexOf");
System.Console.WriteLine(IndexOf(array, 4));
System.Console.WriteLine("End");

void FillArray(int[] collection)
{
    int lenght = collection.Length;

    int index = 0;

    while (index < lenght)
    {
        collection[index] = new Random().Next(1, 10);

        index++;
    }
}

void PrintArray(int[] array)
{
    int count = array.Length;
    int position = 0;

    while (position < count)
    {
        System.Console.WriteLine((array[position]));
        position++;
    }
}

int IndexOf(int[] array, int find)
{
    int count = array.Length;
    int position = find;
    int index = 0;

    while (index < count)
    {
        if (array[index] == find)
        {
            position = index;
            break;
        }
        index++;
    }

    return position;
}