namespace SortUnitTests
{
    public static class QuickSort
    {
        public static int[] Sort(int[] randomNumbers)
        {
            var newArray = CreateNewArray(randomNumbers);

            Sort(newArray, 0, newArray.Length - 1);

            return newArray;
        }

        private static void Sort(int[] array, int firstIndex, int lastIndex)
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
            if (firstIndex < j) Sort(array, firstIndex, j);
            if (i < lastIndex) Sort(array, i, lastIndex);
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