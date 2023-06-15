int firstValue = new Random().Next(1,10);
int secondValue = new Random().Next(1,10);
var result = firstValue + secondValue;

Console.WriteLine($"Первое число: {firstValue}");
Console.WriteLine($"Второе число: {secondValue}");
Console.WriteLine($"Результат сложения: {result}");