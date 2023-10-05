
/*Задача 32: Напишите программу замена элементов массива: положительные элементы замените на
соответствующие отрицательные, и наоборот.
[-4, -8, 8, 2] -> [4, 8, -8, -2]
Задача 33: Задайте массив.Напишите программу, которая определяет, присутствует ли заданное число в массиве.
4; массив[6, 7, 19, 345, 3]->нет
3; массив[6, 7, 19, 345, 3]->да
*/


int[] array = CreateArrayRndInt(10);

PrintArray(array, "Исходный массив");
int[] inverseArray = InverseArray(array);
PrintArray(inverseArray, "Инвертированный массив");



#region Methods
int[] CreateArrayRndInt(int size)
{
    int[] array = new int[size];
    var rnd = new Random();

    for (int i = 0; i < size; i++)
    {
        array[i] = rnd.Next(-100, 101);
    }

    return array;
}


void PrintArray(int[] array, string message)
{
    Console.Write($"{message}: [");

    for (int i = 0; i < array.Length; i++)
    {
        if (i == array.Length - 1) Console.WriteLine($"{array[i]}]");
        else Console.Write($"{array[i]}, ");
    }
}

int[] InverseArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = array[i] * -1;
    }
    return array;
}
#endregion
