using System.Collections.Generic;
using System.Linq;

namespace DelegatesSortUnitTest
{
    public class Sort
    {
        public static int[] Bubble(int[] randomNumbers)
        {
            var newArray = CreateNewArray(randomNumbers);
            bool swap;

            do
            {
                swap = false;

                for (int i = 0; i < newArray.Length - 1; i++)
                {
                    if (newArray[i] > newArray[i + 1])
                    {
                        int temporary = newArray[i + 1];
                        newArray[i + 1] = newArray[i];
                        newArray[i] = temporary;
                        swap = true;
                    }
                }

            }
            while (swap);

            return newArray;
        }

        public static int[] Insert(int[] randoms)
        {
            var sorted = new List<int>();
            sorted.Add(randoms.First());

            foreach (int random in randoms.Skip(1))
            {
                if (random < sorted[0])
                {
                    sorted.Insert(0, random);
                }
                else if (random > sorted[sorted.Count - 1])
                {
                    sorted.Add(random);
                }
                else
                {
                    for (int i = 0; i < sorted.Count; i++)
                    {
                        if (random < sorted[i])
                        {
                            sorted.Insert(i, random);
                            break;
                        }
                    }
                }
            }

            return sorted.ToArray();
        }

        public static int[] Quick(int[] randomNumbers)
        {
            var newArray = CreateNewArray(randomNumbers);

            Quick(newArray, 0, newArray.Length - 1);

            return newArray;
        }

        private static void Quick(int[] array, int firstIndex, int lastIndex)
        {
            int i = firstIndex;
            int j = lastIndex;
            int pivot = array[(firstIndex + lastIndex) / 2];
            while (i < j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    int tmp = array[i];
                    array[i++] = array[j];
                    array[j--] = tmp;
                }
            }
            if (firstIndex < j) Quick(array, firstIndex, j);
            if (i < lastIndex) Quick(array, i, lastIndex);
        }

        private static int[] CreateNewArray(int[] randomNumbers)
        {
            int randomNumbersLength = randomNumbers.Length;
            var array = new int[randomNumbersLength];

            for (int i = 0; i < randomNumbersLength; i++)
            {
                array[i] = randomNumbers[i];
            }

            return array;
        }
    }
}