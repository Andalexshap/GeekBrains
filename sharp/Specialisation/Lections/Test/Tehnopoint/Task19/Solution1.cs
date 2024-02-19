//namespace Tehnopoint.Task19
//{
//    internal class Solution
//    {
//        const char lost = 'L';
//        const char X = 'X';
//        const char Y = 'Y';
//        const char Z = 'Z';
//        public void Test()
//        {
//            int count = int.Parse(Console.ReadLine());

//            for (int i = 0; i < count; i++)
//            {
//                var d = Console.ReadLine();
//                var a = Console.ReadLine().ToArray();
//                //a = "YYYYYXXYXYXYYYZXXYYYYYZXYYYXYZZZXYYZZZXXZYXYYXZZYYZZYYZZZYZYXZYYYZYYZXYYYZYZZYZZXXZZZZYXZXZZZZZXXXYX".ToList();
//                bool isValid = Check(ref a);



//                Console.WriteLine(isValid ? "Yes" : "No");
//            }
//        }
//        static bool Check(ref char[] set)
//        {
//            if (set.Length % 2 != 0)
//                return false;

//            if (!FreeX(ref set))
//                return false;

//            return CheckYZ(ref set);
//        }

//        static bool FreeX(ref char[] set)
//        {
//            int yCount = 0;
//            int zCount = 0;
//            int y = 0;
//            int z = 0;
//            int x = set.Length - 1;

//            while (x >= 0)
//            {
//                while (x >= 0)
//                {
//                    if (set[x] == Y)
//                        yCount++;
//                    else if (set[x] == Z)
//                        zCount++;
//                    else if (set[x] == X)
//                        break;

//                    x--;
//                }

//                if (x < 0)
//                    return true;

//                if (zCount > yCount)
//                {
//                    z = set.Length - 1;
//                    set[x] = lost;

//                    while (z >= 0)
//                    {
//                        if (set[z] == Z)
//                        {
//                            zCount--;
//                            set[x] = lost;
//                            set[z] = lost;
//                            break;
//                        }
//                        z--;
//                    }
//                }
//                else
//                {
//                    y = x + 1;
//                    bool flag = false;

//                    while (y < set.Length)
//                    {
//                        if (set[y] == Y)
//                        {
//                            yCount--;
//                            set[x] = lost;
//                            set[y] = lost;
//                            flag = true;
//                            break;
//                        }
//                        y++;
//                    }
//                    if (!flag)
//                        return false;
//                }

//                x--;
//            }

//            return zCount == yCount;
//        }

//        static bool CheckYZ(ref char[] set)
//        {
//            int counter = 0;

//            for (int i = 0; i < set.Length; i++)
//            {
//                if (set[i] == Y)
//                    counter++;

//                if (set[i] == Z)
//                    counter--;

//                if (counter < 0)
//                    return false;
//            }

//            return true;
//        }
//    }
//}
