namespace HomeWork6
{
    public static class DoubleTryPars
    {
        public static bool DoubleTryParse(this string? input, out double result)
        {
            try
            {
                if (input!.Contains('.'))
                    input = input.Replace('.', ',');

                result = double.Parse(input!);

                if (result <= 0)
                {
                    Console.WriteLine("число отрицательное и будет = 0");
                    result = 0;
                    return false;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Это не число");
                result = 0;
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = 0;
                return false;
            }
            return true;
        }
    }
}
