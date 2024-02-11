namespace Tehnopoint.Task11
{
    internal class Solution
    {
        public void Test()
        {
            using var input = new StreamReader(Console.OpenStandardInput());
            using var output = new StreamWriter(Console.OpenStandardOutput());
            var data = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
            Console.WriteLine(data[0] - data[1]);
        }
    }
}
