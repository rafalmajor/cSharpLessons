using System;

namespace GeneralSortUnitTests
{
    public static class QuickSort
    {
        public static T[] Sort<T>(T[] randomNumbers) where T : IComparable<T>
        {
            var newArray = CreateNewArray(randomNumbers);

            Sort(newArray, 0, newArray.Length - 1);

            return newArray;
        }

        private static void Sort<T>(T[] array, int firstIndex, int lastIndex) where T : IComparable<T>
        {
            int i = firstIndex;
            int j = lastIndex;
            T pivot = array[(firstIndex + lastIndex) / 2];
            while (i < j)
            {
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T tmp = array[i];
                    array[i++] = array[j];
                    array[j--] = tmp;
                }
            }
            if (firstIndex < j) Sort(array, firstIndex, j);
            if (i < lastIndex) Sort(array, i, lastIndex);
        }

        private static T[] CreateNewArray<T>(T[] randomNumbers)
        {
            int randomNumbersLength = randomNumbers.Length;
            var array = new T[randomNumbersLength];

            for (int i = 0; i < randomNumbersLength; i++)
            {
                array[i] = randomNumbers[i];
            }

            return array;
        }
    }
}