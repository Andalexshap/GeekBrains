namespace HomeWork6
{
    public class CalculatorExeption : Exception
    {
        public CalculatorExeption()
        {

        }
        public CalculatorExeption(string error) : base(error)
        {

        }

    }
}
