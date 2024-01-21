using System.Text;

internal class Program
{
    // 2 - первый пример
    // 3 - второй пример
    // 46 - третий пример
    private static string PathToFolder = @"D:\Downloads\46";
    private static void Main(string[] args)
    {
        var test = new Queue<string>();
        var answer = new Queue<string>();

        string[] allfiles = Directory.GetFiles(PathToFolder).Where(x => !x.EndsWith("a")).ToArray();

        foreach (string filename in allfiles)
        {
            StreamReader f = new StreamReader(filename);
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();
                test.Enqueue(s); // что-нибудь делаем с прочитанной строкой s
            }
            f.Close();
            StreamReader fs = new StreamReader($"{filename}.a");
            while (!fs.EndOfStream)
            {
                string s = fs.ReadLine();
                answer.Enqueue(s);
            }
            f.Close();

            var count = int.Parse(test.Dequeue()); // int.Parse(Console.ReadLine()!);
            count = int.Parse(test.Dequeue());
            while (test.Count > 0)
            {
                var ques = test.Dequeue();
                var result = Method2(ques).ToLower();
                var ans = answer.Dequeue().ToLower();
                if (result != ans)
                {

                }
            }
        }

        /*

                //var str = "orderStatus:\"Cancelled\",\"Completed\",\"Confirmed\" status:\"Rejected\",\"Approval Needed\" createddate:[2023-12-06 TO]";

                //var res = str.Split("\" ");

                //var orderStatus = res.FirstOrDefault(x => x.Contains("orderStatus"))?
                //    .Replace("orderStatus:", "").Replace("\"", "").Split(",");

                //var status = res.FirstOrDefault(x => x.Contains("status"))?
                //    .Replace("status:", "").Replace("\"", "").Split(",");

                //var createddate = res.FirstOrDefault(x => x.Contains("createddate"))?
                //    .Replace("createddate:", "").Replace("[", "").Replace("]", "").Split(" TO ");
                //if (createddate != null && createddate.Length > 1)
                //{
                //    DateTime? startDate = !string.IsNullOrEmpty(createddate[0]) ? DateTime.Parse(createddate[0]) : null;
                //    DateTime? endDate = !string.IsNullOrEmpty(createddate[1]) ? DateTime.Parse(createddate[1]) : null;
                //}
                //Console.ReadLine();
        */
        /*
        var count = int.Parse(Console.ReadLine() ?? "0");
        for (int i = 0; i < count; i++)
        {
            var str = Console.ReadLine();
            var s = str.OrderByDescending(x => x).ToArray();
            if(s.Length > 9)
            {
                var result = (s[0] != s[1] && s[2] != s[3] && s[5] != s[6]) ? "Yes" : "No";
                Console.WriteLine(result);
            }
    
        }
         */
    }

    private static void Method2()
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
                    result = day <= 29 ? "yes" : "no";
                }
                else
                    result = day <= 28 ? "yes" : "no";
            }
            else if (new[] { 4, 6, 9, 11 }.Contains(month))
            {
                result = day <= 30 ? "yes" : "no";
            }
            result = day <= 31 ? "yes" : "no"; ;
            Console.WriteLine(result);
        }
    }
    private static string Method2(string message)
    {
        var arrDate = message.Split(' ');
        var month = int.Parse(arrDate[1]);
        var year = int.Parse(arrDate[2]);
        var day = int.Parse(arrDate[0]);
        if (month == 2)
        {
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                return day <= 29 ? "yes" : "no";
            }
            else
                return day <= 28 ? "yes" : "no";
        }
        else if (new[] { 4, 6, 9, 11 }.Contains(month))
        {
            return day <= 30 ? "yes" : "no";
        }
        return day <= 31 ? "yes" : "no"; ;
    }

    private static string Method2Var(string message)
    {
        return DateTime.TryParse(message, out var _) ? "Yes" : "No";
    }

    private static void Method3()
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
    private static string Method3(string s)
    {
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
            {
                sb.Append(' ');
            }
        }

        if (s.Length == 0) result = sb.ToString();
        return result;
    }

    private static void Method4()
    {
        var countTest = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < countTest; i++)
        {
            var tempRange = new int[15, 30];
            var countPeople = int.Parse(Console.ReadLine()!);
            for (int k = 0; k < countPeople; k++)
            {

            }

        }
    }
}

