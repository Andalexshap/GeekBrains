using System.Text.Json;

namespace Tehnopoint.Task15
{
    internal class Solution
    {
        public class A
        {
            public string dir { get; set; }
            public List<string> files { get; set; } = new List<string>();
            public List<A> folders { get; set; } = new List<A>();
        }

        public void Test()
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());

                string json = "";
                for (int j = 0; j < n; j++)
                {
                    json += Console.ReadLine();
                }
                var s = JsonSerializer.Deserialize<A>(json, new JsonSerializerOptions { MaxDepth = 1025 });
                var count = 0;
                if (s.files.Any(x => x.EndsWith(".hack")))
                {
                    count += s.files.Count;
                    count += Check(s.folders, true);
                }
                else
                {
                    count += Check(s.folders, false);
                }

                Console.WriteLine(count);
            }
        }

        public int Check(List<A> a, bool all)
        {
            int count = 0;
            if (all)
            {
                foreach (var dir in a)
                {
                    count += dir.files.Count;
                    count += Check(dir.folders, true);
                }
            }
            else
            {
                foreach (var item in a)
                {
                    if (item.files.Any(x => x.EndsWith(".hack")))
                    {
                        count += item.files.Count + Check(item.folders, true);
                    }
                    else
                    {
                        foreach (var subDirectory in item.folders)
                        {
                            count += Check(subDirectory.folders, false);
                        }
                    }

                }
            }

            return count;
        }
    }
}
