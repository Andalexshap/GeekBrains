using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehnopoint.Task1
{
    internal class Solution
    {
        public void Test()
        {
            var count = int.Parse(Console.ReadLine() ?? "0");
            for (int i = 0; i < count; i++)
            {
                var str = Console.ReadLine();
                var s = str.OrderByDescending(x => x).ToArray();
                if (s.Length > 9)
                {
                    var result = (s[0] != s[1] && s[2] != s[3] && s[5] != s[6]) ? "YES" : "NO";
                    Console.WriteLine(result);
                }
            }
        }
    }
}
