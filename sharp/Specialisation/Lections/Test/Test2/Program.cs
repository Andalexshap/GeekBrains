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
