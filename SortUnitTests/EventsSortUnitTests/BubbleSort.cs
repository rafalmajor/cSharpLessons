using System;

namespace EventsSortUnitTests
{
    public class BubbleSort : ISort
    {
        public event EventHandler Done;

        public int[] Input { private get; set; }

        public int[] Output { get; private set; }

        public void Sort()
        {
            this.Output = CreateNewArray(this.Input);
            bool swap;

            do
            {
                swap = false;

                for (int i = 0; i < this.Output.Length - 1; i++)
                {
                    if (this.Output[i] > this.Output[i + 1])
                    {
                        int temporary = this.Output[i + 1];
                        this.Output[i + 1] = this.Output[i];
                        this.Output[i] = temporary;
                        swap = true;
                    }
                }
            }
            while (swap);

            this.Done?.Invoke(this, EventArgs.Empty);
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