using System.Diagnostics.Metrics;

namespace Tehnopoint.Task17
{
    internal class Solution
    {
        public void Test()
        {
            int count = int.Parse(Console.ReadLine());
            List<string> logins = new List<string>();
            for (int i = 0; i < count; i++)
            {
                logins.Add(Console.ReadLine());
            }

            int inputCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputCount; i++)
            {
                string newLogin = Console.ReadLine();
                bool result = false;
               
                foreach (string existLogin in logins.Where(x => x.Length == newLogin.Length))
                {
                    if (Compair(existLogin, newLogin))
                    {
                        result = true;
                        break;
                    }
                }

                Console.WriteLine(result ? "1" : "0");
            }

            static bool Compair(string existLogin, string newLogin)
            {
                if (existLogin == newLogin)
                    return true;

                //if (!existLogin.OrderBy(x => x).SequenceEqual(newLogin.OrderBy(x => x)))
                //{
                //    return false;
                //}
               
                int diffCount = 0;
                char? symbol1 = null;
                char? symbol2 = null;
                for (int i = 0; i < existLogin.Length; i++)
                {
                    if (existLogin[i] != newLogin[i])
                    {
                        diffCount++;
                        if (diffCount > 1 && (symbol1 != newLogin[i] || symbol2 != existLogin[i]))
                            return false;
                        if (diffCount > 2)
                            return false;
                        symbol1 = existLogin[i];
                        symbol2 = newLogin[i];
                    }
                    else if (existLogin[i] == newLogin[i] && diffCount == 1)
                        return false;
                }

                return diffCount == 2;
            }
        }
    }
}
