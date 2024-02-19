namespace Tehnopoint.Task19
{
    internal class Solution
    {
        public void Test()
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var d = Console.ReadLine();
                var a = Console.ReadLine().ToList();
                //a = "YYYYYXXYXYXYYYZXXYYYYYZXYYYXYZZZXYYZZZXXZYXYYXZZYYZZYYZZZYZYXZYYYZYYZXYYYZYZZYZZXXZZZZYXZXZZZZZXXXYX".ToList();
                bool isValid = true;
                if (a.First() == 'Z' || a.Last() == 'X')
                    isValid = false;


                while (a.Count > 0 && isValid)
                {
                    var xCount = a.Where(x => x == 'X').Count();
                    var yCount = a.Where(x => x == 'Y').Count();
                    var zCount = a.Where(x => x == 'Z').Count();

                    var firstValue = a.First();
                    a.Remove(firstValue);

                    switch (firstValue)
                    {
                        case 'X':
                            {
                                int secondValue = -1;
                                if (a.First() == 'Z')
                                {
                                    a.Remove('Z');
                                    break;
                                }

                                if (zCount > yCount)
                                {
                                    secondValue = a.IndexOf('Z');
                                    if (secondValue == -1)
                                        secondValue = a.LastIndexOf('Y');
                                }
                                else
                                {
                                    secondValue = a.LastIndexOf('Y');
                                    if (secondValue == -1)
                                        secondValue = a.IndexOf('Z');
                                }

                                if (secondValue != -1)
                                {
                                    a.RemoveAt(secondValue);
                                }
                                else
                                {
                                    isValid = false;
                                }
                                break;
                            }
                        case 'Y':
                            {
                                int secondValue = -1;
                                if (a.First() == 'Z')
                                {
                                    a.Remove('Z');
                                    break;
                                }
                                if (zCount > xCount)
                                {
                                    secondValue = a.IndexOf('Z');
                                    if (secondValue == -1)
                                        secondValue = a.LastIndexOf('X');

                                }
                                else
                                {
                                    secondValue = a.LastIndexOf('X');
                                    if (secondValue == -1)
                                        secondValue = a.IndexOf('Z');

                                }

                                if (secondValue != -1)
                                {
                                    a.RemoveAt(secondValue);
                                }
                                else
                                {
                                    isValid = false;
                                }
                                break;
                            }
                        default:
                            {
                                isValid = false;
                                break;
                            }
                    }
                }

                Console.WriteLine(isValid ? "Yes" : "No");
            }
        }
    }
}
