using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LambdaBubbleSortUnitTest
{
    [TestClass]
    public class LambdaBubbleSortUnitTest
    {
        private readonly int[] randomItems = { 16, 4, 19, 5, 15, 3, 18, 9, 11, 7, 20, 14, 1, 12, 8, 10, 2, 6, 13, 17 };

        private readonly int[] sortedItems = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        [TestMethod]
        public void LambdaBubbleSortTest()
        {
            Func<int[], int[]> lambdaBubbleSort = (randomNumbers) =>
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
            };

            var sorted = lambdaBubbleSort(this.randomItems);
            CollectionAssert.AreEqual(this.sortedItems, sorted);
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
