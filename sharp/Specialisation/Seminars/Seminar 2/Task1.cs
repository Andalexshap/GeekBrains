namespace Seminar_2
{
    internal class Task1
    {
        public void Solution()
        {
            List<int> ints = new List<int> { 0, 1, 1, -1, 101, 102, 101, 11, 1111, 11 };
            ints = ints.Distinct().ToList();
            Console.WriteLine(string.Join(", ", ints));

            ints = new List<int> { 0, 1, 1, -1, 101, 102, 101, 11, 1111, 11 };
            for (int i = 0; i < ints.Count; i++)
            {
                while (ints.FindAll(x => x == ints[i]).Count > 1)
                {
                    ints.Remove(ints[i]);
                }
            }
            Console.WriteLine(string.Join(", ", ints));
        }
    }
}
