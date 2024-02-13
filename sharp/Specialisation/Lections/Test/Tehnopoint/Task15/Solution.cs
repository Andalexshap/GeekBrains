using System.Text.Json;

namespace Tehnopoint.Task15
{
    internal class Solution
    {
        public class A
        {
            public string dir { get; set; }
            public List<string> files { get; set; }
            public List<A> folders { get; set; }
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
                var s = JsonSerializer.Deserialize<A>(json, new JsonSerializerOptions { MaxDepth = 2048 });
                var count = 0;
                Check(s, false);

                Console.WriteLine(count);

                void Check(A a, bool IsHack)
                {
                    if (IsHack)
                    {
                        count += a.files?.Count ?? default;
                        a.folders?.ForEach(x => Check(x, true));
                    }
                    else
                    {
                        if(a.files != null && a.files.Any(x => x.EndsWith(".hack")))
                        {
                            count += a.files.Count;
                            a.folders?.ForEach(x => Check(x, true));
                        }
                        else
                        {
                            a.folders?.ForEach(x => Check(x, false));
                        }
                    }
                }
            }
        }
    }
}
