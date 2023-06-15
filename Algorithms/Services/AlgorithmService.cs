using System.Diagnostics.Metrics;
using System.Reflection;

public static class AlgorithmService
{
    public static int[] CreateRandomIntArray(int size = 30, int minValue = -100, int maxValue = 100)
        => Enumerable.Range(minValue, size).Select(i => i = new Random().Next(minValue, maxValue)).ToArray();

    public static void Copy(this int[] secondArray, int[] firstArray)
        => Array.Copy(firstArray, secondArray, firstArray.GetUpperBound(0) - 1);
    public static int[] Copy(int[] targetArray)
    {
        int[] copyArrray = (new int[targetArray.GetUpperBound(0) - 1]);
        copyArrray.Copy(targetArray);
        return copyArrray;
    }

    public static void BubbleSort(this int[] array, out int counter)
    {
        counter = 0;
        bool finish;

        do
        {
            finish = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    var temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    finish = true;
                }
                counter++;
            }
        }
        while (finish);
    }

    public static void DirectSort(this int[] array, out int counter)
    {
        counter = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minPosition = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minPosition])
                {
                    minPosition = j;
                }
                counter++;
            }
            if (minPosition != i)
            {
                var temp = array[i];
                array[i] = array[minPosition];
                array[minPosition] = temp;
            }
        }
    }

    public static void InsertSort(this int[] array, out int counter)
    {
        counter = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] > array[j])
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
                counter++;
            }
        }
    }

    public static void QuickSort(this int[] array, int startPosition, int endPosition, out long counter, long count = 0)
    {
        counter = count;
        int leftPosition = startPosition;
        int rightPosition = endPosition;
        int pivot = array[(startPosition + endPosition) / 2];
        do
        {
            counter++;
            while (array[leftPosition] < pivot) leftPosition++;
            while (array[rightPosition] > pivot) rightPosition--;

            if (leftPosition <= rightPosition)
            {
                if (leftPosition < rightPosition)
                {
                    int temp = array[leftPosition];
                    array[leftPosition] = array[rightPosition];
                    array[rightPosition] = temp;
                }
                leftPosition++;
                rightPosition--;
            }
        }
        while (leftPosition <= rightPosition);

        if (leftPosition < endPosition) QuickSort(array, leftPosition, endPosition, out counter, counter);
        if (startPosition < rightPosition) QuickSort(array, startPosition, rightPosition, out counter, counter);
    }

    public static void HeapSort(this int[] array, out int counter)
    {
        counter = 0;
        int n = array.Length;

        for (int i = (n / 2) - 1; i >= 0; i--)
        {
            Heapify(array, n, i, out counter, counter);
        }

        for (int i = n - 1; i > 0; i--)
        {
            int temporary = array[0];
            array[0] = array[i];
            array[i] = temporary;

            array.Heapify(n, 0, out counter, counter);
        }
    }

    private static void Heapify(this int[] array, int n, int i, out int counter, int count)
    {
        counter = count;
        counter++;
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && array[left] > array[largest]) { largest = left; }
        if (right < n && array[right] > array[largest]) { largest = right; }

        if (largest != i)
        {
            int temporary = array[i];
            array[i] = array[largest];
            array[largest] = temporary;

            array.Heapify(n, largest, out counter, counter);
        }
    }
}