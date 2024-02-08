using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehnopoint.Task3
{
    internal class Solution
    {
        public void Test()
        {
            var count = int.Parse(Console.ReadLine() ?? "0");
            for (int i = 0; i < count; i++)
            {
                var s = Console.ReadLine();
                var result = "-";
                var sb = new StringBuilder();
                while (s.Length >= 4)
                {
                    var sub = "";
                    if (s.Length > 4 && (char.IsLetter(s[0]) && char.IsDigit(s[1]) && char.IsDigit(s[2]) && char.IsLetter(s[3]) && char.IsLetter(s[4])))
                        sub = s.Substring(0, 5);
                    else if (char.IsLetter(s[0]) && char.IsDigit(s[1]) && char.IsLetter(s[2]) && char.IsLetter(s[3]))
                        sub = s.Substring(0, 4);
                    else break;

                    s = s.Substring(sub.Length);
                    sb.Append(sub);
                    if (s.Length >= 4)
                        sb.Append(' ');
                }

                if (s.Length == 0) result = sb.ToString();
                Console.WriteLine(result);
            }
        }
    }
}
