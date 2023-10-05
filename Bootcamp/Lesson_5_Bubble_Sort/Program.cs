using static System.Console;

int[] array = Enumerable.Range(1,10).Select(x => Random.Shared.Next(1,10)).ToArray();

WriteLine($"Начальный массив: [{string.Join(", ", array)}]");
for(int i = 0; i < array.Length; i++)
{
    for(int j = 0; j < array.Length -1; j++)
    {
        if (array[j] > array[j+1])
        {
            int temp = array[j];
            array[j] = array[j+1];
            array[j+1] = temp;
            
        }
    }
    WriteLine($"{i}.[{string.Join(", ", array)}]");
}

