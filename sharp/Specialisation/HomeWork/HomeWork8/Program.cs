using HomeWork8;

internal class Program
{
    //Напишите утилиту которая ищет
    //файлы определенного расширения с указанным текстом. Рекурсивно.
    //Пример вызова утилиты: utility.exe txt текст.
    private static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Необходмо ввсести мимнимум 2 аргумента");
            Environment.Exit(0);
        }

        string extension = args[0];
        string targetWorld = args[1];

        var util = new FileUtils();
        util.SetMainDirectory(@"C:\Users\shapovalov\Documents\123");
        util.SetFileExtension(extension);
        util.SetTargetWorld(targetWorld);

        util.FindAllFiles();
        Console.WriteLine();
        Console.WriteLine(string.Join("\n", util.FindResult));
        Console.ReadKey();
    }

}