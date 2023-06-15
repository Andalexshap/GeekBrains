using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Services
{
    public static class SearchService
    {
        public static (int index, int counter) Search(int[] array, int targetValue)
        {
            var index = -1;
            var counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                counter++;
                if (array[i] == targetValue)
                {
                    return (i, counter);
                }
            }
            return (index, counter);
        }

        public static (int index, int counter) BinarySearch(int[] array, int targetValue, int min, int max, int count = 0)
        {
            count++;

            int midpoint;
            if (max < min) return (-1, count);
            else
            {
                midpoint = (max - min) / 2 + min;
            }

            if (array[midpoint] < targetValue) return BinarySearch(array, targetValue, midpoint + 1, max, count);
            else
            {
                if (array[midpoint] > targetValue) return BinarySearch(array, targetValue, min, midpoint - 1, count);
                else return (midpoint, count);
            }
        }
    }
}
