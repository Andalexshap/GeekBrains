using Exeptions.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] firstArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] secondArray = { 0, 1, 2, 3, 4, 5, 6 };
        int[] thirdArray = { 15, 14, 13, 20, 45, 10, 2, 5, 4, 56 };

        try
        {
            Console.WriteLine($"{nameof(DevideWithoutErrorHandling)}: " + DevideWithoutErrorHandling(5, 0));
            Console.WriteLine($"{nameof(DevideWithErrorHandling)}: " + DevideWithErrorHandling(5, 0));


            Console.WriteLine($"{nameof(AdditionArrayValueWithErrorHandling)}: " + PrintArray(AdditionArrayValueWithErrorHandling(firstArray, secondArray)));
            Console.WriteLine($"{nameof(AdditionArrayValueWithErrorHandling)}: " + PrintArray(AdditionArrayValueWithErrorHandling(firstArray, thirdArray)));

            Console.WriteLine($"{nameof(AdditionArrayValueWithoutErrorHandling)}: " + PrintArray(AdditionArrayValueWithoutErrorHandling(firstArray, secondArray)));
            Console.WriteLine($"{nameof(AdditionArrayValueWithoutErrorHandling)}: " + PrintArray(AdditionArrayValueWithoutErrorHandling(firstArray, thirdArray)));

            IsGenerateInvalidCastExceptionWithoutErrorHandling(false);
            IsGenerateInvalidCastExceptionWithoutErrorHandling(true);

            IsGenerateInvalidCastExceptionWithErrorHandling(true);

        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка:" + ex.Message);

        }
    }

    // DivideByZeroException
    public static T DevideWithoutErrorHandling<T>(T firstValue, T secondValue) where T : struct
        => (dynamic)firstValue / (dynamic)secondValue;

    public static T DevideWithErrorHandling<T>(T firstValue, T secondValue) where T : struct
    {
        if ((dynamic)secondValue == 0)
        {
            throw new ArgumentException("На ноль делить нельзя");
        }

        return (dynamic)firstValue / (dynamic)secondValue;
    }

    //IndexOutOfRangeException
    public static T[] AdditionArrayValueWithErrorHandling<T>(T[] firstArray, T[] secondArray) where T : struct
    {
        if (firstArray.Length != secondArray.Length)
        {
            throw new ArgumentException("Массивы разной длины");
        }

        T[] result = new T[firstArray.Length];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = (dynamic)firstArray[i] + (dynamic)secondArray[i];
        }

        return result;
    }

    public static T[] AdditionArrayValueWithoutErrorHandling<T>(T[] firstArray, T[] secondArray) where T : struct
    {
        T[] result = new T[firstArray.Length];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = (dynamic)firstArray[i] + (dynamic)secondArray[i];
        }

        return result;
    }


    public static void IsGenerateInvalidCastExceptionWithoutErrorHandling(bool isGenerateExeption)
    {
        object obj = "you";

        if (isGenerateExeption)
        {
            int num = (int)obj;
        }
    }

    public static void IsGenerateInvalidCastExceptionWithErrorHandling(bool isGenerateExeption)
    {
        object obj = "you";

        if (isGenerateExeption)
        {
            try
            {
                int num = (int)obj;
            }
            catch
            {
                throw new CustomException("Ошибка приведения типов");
            }
        }
    }

    public static string PrintArray<T>(T[] array)
        => String.Join(" | ", array);

}