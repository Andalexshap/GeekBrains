using Seminar1;

internal class Program
{
	private static void Main(string[] args)
	{
		var value = new Bits(7);

		var a = "";
		try
		{
			for (int j = 0; j < 8; j++)
			{
				a += value.GetBit(j) ? 1 : 0;

			}
			a = string.Join("", a.Reverse());

			Console.WriteLine(a);
			Console.WriteLine(value.GetBit(2));

			value.SetBit(false, 2);
			Console.WriteLine(value.Value);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		long l = 1234;
		int i = 123;
		short s = 12;
		byte b = 1;
		Bits resultL = l;
        Bits resultI = i;
        Bits resultS = s;
        Bits resultB = b;
    }
}