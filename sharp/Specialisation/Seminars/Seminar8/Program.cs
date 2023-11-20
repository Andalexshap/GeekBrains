internal class Program
{
    private static void Main(string[] args)
    {
        //Пример запуска: utility.exe c:\\ file1.txt
        var mainPath = args[0];
        string fileName = args[1];

        SomeMethod(mainPath, fileName);
    }

    public static void SomeMethod(string directoty, string fileName)
    {
        var dirs = Directory.EnumerateDirectories(directoty);
        var files = Directory.EnumerateFiles(directoty);
        foreach (var file in files)
        {
            if (file.Contains(fileName))
            {
                Console.WriteLine($"Искомый файл {fileName}, " +
                    $"находится в {directoty}");
                break;
            }
        }

        foreach (var dir in dirs)
        {
            SomeMethod(dir, fileName);
        }
    }
}
