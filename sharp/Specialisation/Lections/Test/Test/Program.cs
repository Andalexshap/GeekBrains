internal class Program
{
    private static void Main(string[] args)
    {
        var str = "orderStatus:\"Cancelled\",\"Completed\",\"Confirmed\" status:\"Rejected\",\"Approval Needed\" createddate:[2023-12-06 TO]";

        var res = str.Split("\" ");

        var orderStatus = res.FirstOrDefault(x => x.Contains("orderStatus"))?
            .Replace("orderStatus:", "").Replace("\"", "").Split(",");

        var status = res.FirstOrDefault(x => x.Contains("status"))?
            .Replace("status:", "").Replace("\"", "").Split(",");

        var createddate = res.FirstOrDefault(x => x.Contains("createddate"))?
            .Replace("createddate:", "").Replace("[", "").Replace("]", "").Split(" TO ");
        if (createddate != null && createddate.Length > 1)
        {
            DateTime? startDate = !string.IsNullOrEmpty(createddate[0]) ? DateTime.Parse(createddate[0]) : null;
            DateTime? endDate = !string.IsNullOrEmpty(createddate[1]) ? DateTime.Parse(createddate[1]) : null;
        }
        Console.ReadLine();

    }
}