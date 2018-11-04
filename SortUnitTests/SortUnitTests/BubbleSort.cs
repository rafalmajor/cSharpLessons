namespace SortUnitTests
{
    public static class BubbleSort
    {
        public static int[] Sort(int[] randomNumbers)
        {
            var newArray = CreateNewArray(randomNumbers);
            bool swap;

            do
            {
                swap = false;

                for (int i = 0; i < newArray.Length-2; i++)
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