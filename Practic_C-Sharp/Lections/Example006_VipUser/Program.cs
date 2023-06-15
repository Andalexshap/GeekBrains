Console.Write("Введите ваше имя ");

string? userName = Console.ReadLine();

if(userName?.ToLower() == "маша")
{
    Console.WriteLine("Привет, МАША!!!");
}
else
{
Console.WriteLine($"Привет, {userName}");
}
