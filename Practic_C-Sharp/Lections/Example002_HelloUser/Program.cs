Console.WriteLine("Введите Ваше имя ");

string? username = Console.ReadLine();

if(string.IsNullOrEmpty(username))
{
Console.WriteLine("Вы не вели имя");
}
else
{
Console.WriteLine($"Привет, {username}!");
}