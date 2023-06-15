// Задать номер четверти, показать диапазоны для возможных координат
Console.WriteLine("Отображение возможных координат для введенной четверти плоскости");

Console.Write("Введите номер четверти от1 до 4х: ");

string str = Console.ReadLine()!;

if(str == "1") Console.WriteLine("Возможные координаты X = (0 : + infinity) ,Y = (0 : + infinity)");
else if(str == "2") Console.WriteLine("Возможные координаты X = (- infinity : 0) ,Y = (0 : + infinity)"); 
else if(str == "3") Console.WriteLine("Возможные координаты X = (- infinity : 0) ,Y = (- infinity : 0)"); 
else if(str == "4") Console.WriteLine("Возможные координаты X = (0 : + infinity) ,Y = (- infinity : 0)");
else Console.WriteLine("Введенное значение не попадает в диапазон от 1 до 4х");
