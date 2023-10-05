public static class Infrastucture
{
    public static int[] CreateArray(this int size, int min = 0, int max = 10)
    {
        return Enumerable.Range(1, size).Select(x => Random.Shared.Next(min, max)).ToArray();
    }

    public static int[] Print(this int[] array, string separator = ", ")
    {
        string output = string.Join(separator, array);
        Console.WriteLine($"[{output}]");
        return array;
    }
}
