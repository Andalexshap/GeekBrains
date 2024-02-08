using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehnopoint.Task2
{
    internal class Solution
    {
        public void Test()
        {
            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var datestr = Console.ReadLine();
                var result = "no";
                var arrDate = datestr.Split(' ');
                var month = int.Parse(arrDate[1]);
                var year = int.Parse(arrDate[2]);
                var day = int.Parse(arrDate[0]);
                if (month == 2)
                {
                    if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                    {
                        result = day <= 29 ? "YES" : "NO";
                    }
                    else
                        result = day <= 28 ? "YES" : "NO";
                }
                else if (new[] { 4, 6, 9, 11 }.Contains(month))
                {
                    result = day <= 30 ? "YES" : "NO";
                }
                else
                {
                    result = day <= 31 ? "YES" : "NO"; ;
                }
                Console.WriteLine(result);
            }
        }
    }
}
