namespace Tehnopoint.Task17
{
    internal class Solution
    {
        public void Test()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> logins = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string login = Console.ReadLine();
                logins.Add(login);
            }

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string login = Console.ReadLine();
                bool foundSimilar = false;
                foreach (string existingLogin in logins)
                {
                    if (IsSimilar(existingLogin, login))
                    {
                        foundSimilar = true;
                        break;
                    }
                }

                Console.WriteLine(foundSimilar ? "1" : "0");
            }
        }

        static bool IsSimilar(string s1, string s2)
        {
            if (s1 == s2)
                return true;

            if (s1.Length != s2.Length)
                return false;

            int diffCount = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    diffCount++;
                    if (diffCount > 2)
                        return false;
                }
                else
                    diffCount = 0;
            }

            return diffCount == 2;
        }
    }
}
