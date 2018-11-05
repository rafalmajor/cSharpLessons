using System;

namespace GeneralSortUnitTests
{
    public static class BubbleSort

    {
        public static T[] Sort<T>(T[] randomNumbers)
            where T : IComparable<T>
        {
            var newArray = CreateNewArray(randomNumbers);
            bool swap;

            do
            {
                swap = false;

                for (int i = 0; i < newArray.Length - 1; i++)
                {
                    if (newArray[i].CompareTo(newArray[i + 1]) > 0)
                    {
                        T temporary = newArray[i + 1];
                        newArray[i + 1] = newArray[i];
                        newArray[i] = temporary;
                        swap = true;
                    }
                }
            }
            while (swap);

            return newArray;
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