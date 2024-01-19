internal class Program
{
    private static string PathToFolder = @"D:\Downloads\3";
    private static void Main(string[] args)
    {
        var test = new List<string>();
        var answer = new List<string>();

        string[] allfiles = Directory.GetFiles(PathToFolder).Where(x => !x.EndsWith("a")).ToArray();

        foreach (string filename in allfiles)
        {
            StreamReader f = new StreamReader(filename);
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();
                test.Add(s); // что-нибудь делаем с прочитанной строкой s
            }
            f.Close();
            StreamReader fs = new StreamReader($"{filename}.a");
            while (!fs.EndOfStream)
            {
                string s = fs.ReadLine();
                answer.Add(s);
            }
            f.Close();







        }



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

    }
}