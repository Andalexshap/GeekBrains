// Программа проверяет пятизначное число на палиндромом.

Console.WriteLine("Проверка числа на полиндром");
Console.WriteLine("Введите любое число: ");

string str = Console.ReadLine() ?? "0";
int number = int.Parse(str);

int[] array = new int[str.Length];
int palindrom = number;
int count = 0;
int end = str.Length - 1;
bool result = true;


while (count < str.Length)
{
    array[count] = palindrom % 10;
    count++;
    palindrom /= 10;
}

count = 0;

while (count <= (str.Length - 1)/ 2)
{
    if (array[count] != array[end])
    {
        result = false;
        break;
    }

    count++;
    end--;
}

if (result)
{
    Console.WriteLine($"Число {number} является палиндромом!");
}
else
{
    Console.WriteLine($"Число {number} не является палиндромом!");
}
