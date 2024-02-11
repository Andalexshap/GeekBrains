namespace Tehnopoint.Task13
{
    internal class Solution
    {
        public void Test()
        {
            var count = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < count; i++)
            {
                var condition = Console.ReadLine()!;

                if (!condition.StartsWith("M") || !condition.EndsWith("D"))
                {
                    Console.WriteLine("NO");
                    continue;
                }

                char preview = 'M';
                var isValid = true;

                foreach (var c in condition.Substring(1))
                {
                    switch (c)
                    {
                        case 'M':
                            {
                                if (!new[] { 'C', 'D' }.Contains(preview))
                                    isValid = false;

                                preview = 'M';
                                break;
                            }
                        case 'R':
                            {
                                if (!new[] { 'M', 'D' }.Contains(preview))
                                    isValid = false;

                                preview = 'R';
                                break;
                            }
                        case 'C':
                            {
                                if (!new[] { 'M', 'R' }.Contains(preview))
                                    isValid = false;

                                preview = 'C';
                                break;
                            }
                        case 'D':
                            {
                                if (!new[] { 'M' }.Contains(preview))
                                    isValid = false;

                                preview = 'D';
                                break;
                            }

                    }

                    if (!isValid)
                        break;
                }
                if (preview == 'D' && isValid)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }

        }
    }
}
//if (new[] { 'M', 'R', 'C', 'D' }.Contains(preview))
