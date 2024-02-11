namespace Tehnopoint.Task12
{
    internal class Solution
    {
        public void Test()
        {
            var count = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < count; i++)
            {
                var data = Console.ReadLine().Split(" ");
                var productsCount = int.Parse(data[0]);
                var discount = decimal.Parse(data[1]) / 100;
                decimal losses = 0;
                for (int j = 0; j < productsCount; j++)
                {
                    var price = int.Parse(Console.ReadLine()!);
                    decimal priceWithDiscount = price * discount;
                    losses += Math.Round(priceWithDiscount, 2) % 1;
                }
                Console.WriteLine(losses.ToString("0.00").Replace(",", "."));
            }

        }
    }
}
