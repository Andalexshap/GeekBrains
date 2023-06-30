internal class Program
{
    private static void Main(string[] args)
    {
        InputStringValueOutputFloatValue();
        EightArrayElementDevideByZero(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        EightArrayElementDevideByZero(new int[] { 1, 2, 3 });
    }

    #region Task1
    /// <summary>
    /// Реализуйте метод, который запрашивает у пользователя ввод дробного числа (типа float), и возвращает введенное значение. 
    /// Ввод текста вместо числа не должно приводить к падению приложения, вместо этого, необходимо повторно запросить у пользователя ввод данных.
    /// </summary>
    public static float InputStringValueOutputFloatValue()
    {
        var tokenFactory = new CancellationTokenSource();
        var token = tokenFactory.Token;
        var floatValue = 0F;

        while (!token.IsCancellationRequested)
        {
            Console.WriteLine("Введите дробное число (разделитель ',')");
            var stringValue = Console.ReadLine();
            try
            {
                floatValue = StringToFloat(stringValue!);
                tokenFactory.Cancel();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Попробуйте еще раз!");
            }
        }

        Console.WriteLine($"Введенное число: {floatValue}");

        return floatValue;
    }



    private static float StringToFloat(string str)
    {
        var result = 0F;

        if (!float.TryParse(str, out result))
        {
            throw new ArgumentException("Введенные данные не валидны");
        }

        return result;
    }
    #endregion

    #region Task2
    /// <summary>
    /// Если необходимо, исправьте код:
    /// try {
    ///      int d = 0;
    ///      double catchedRes1 = intArray[8] / d;
    ///      System.out.println("catchedRes1 = " + catchedRes1);
    /// } catch (ArithmeticException e) {
    ///      System.out.println("Catching exception: " + e);
    /// }
    /// </summary>
    /// <param name="intArray"></param>
public static void EightArrayElementDevideByZero(int[] intArray)
    {
        try
        {
            int d = 0;
            double catchedRes1 = intArray[8] / d;
            Console.WriteLine("catchedRes1 = " + catchedRes1);
        }
        catch (ArithmeticException e)
        {
            Console.WriteLine("Catching exception: " + e);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine("Index exception: " + e);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    #endregion

    #region Task3
    //Метод main не должен выкидывать Exception, так как он является точкой входа. "Сверху" некому обрабатывать исключения
    //PrintSum ни при каких обстоятельствах не вернет FileNotFoundException
    //Основной класс Throwable должены идти замыкающим по ошибкам

    /// <summary>
    /// public static void main(String[] args) throws Exception
    ///  {
    ///      try {
    ///              int a = 90;
    ///      int b = 3;
    ///      System.out.println(a / b);
    ///      printSum(23, 234);
    ///      int[] abc = { 1, 2 };
    ///      abc[3] = 9;
    ///          } catch (Throwable ex) {
    ///      System.out.println("Что-то пошло не так...");
    ///  } catch (NullPointerException ex) {
    ///      System.out.println("Указатель не может указывать на null!");
    ///  } catch (IndexOutOfBoundsException ex) {
    ///      System.out.println("Массив выходит за пределы своего размера!");
    ///  }   
    ///      }
    ///      public static void printSum(Integer a, Integer b) throws FileNotFoundException
    ///  {
    ///      System.out.println(a + b);
    ///  }
    /// </summary>
    /// <param name="args"></param>
    public static void NotMain(String[] args = null)
    {
        try {
            int a = 90;
            int b = 3;
            Console.WriteLine(a / b);
            PrintSum(23, 234);
            int[] abc = { 1, 2 };
            abc[3] = 9;
        
        } catch (EntryPointNotFoundException ex) {
            Console.WriteLine("Указатель не может указывать на null!" + ex.Message);
        } catch (IndexOutOfRangeException ex) {
            Console.WriteLine("Массив выходит за пределы своего размера!" + ex.Message);
        } catch (Exception ex) {
            Console.WriteLine("Что-то пошло не так..." + ex.Message);
        }   
    }
    public static void PrintSum(int a, int b)
    {
        Console.WriteLine(a + b);
    }

    #endregion

    #region Task4

    /// <summary>
    /// Разработайте программу, которая выбросит Exception, когда пользователь вводит пустую строку.
    /// Пользователю должно показаться сообщение, что пустые строки вводить нельзя.
    /// </summary>
    /// <param name="args"></param>

    public static void ThrowExeptionIfInputStringIsNullOrEmpty()
    {
        Console.WriteLine("Введите данные");
        string value = Console.ReadLine()!;

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException("Строка не может быть пустой");
        }
    }
    #endregion
}