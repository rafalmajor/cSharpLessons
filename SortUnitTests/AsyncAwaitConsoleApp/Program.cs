using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitConsoleApp
{
    class Program
    {
        private static readonly string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private readonly static int[] randomItems =
        {
            16, 4, 19, 5, 15, 3, 18, 9, 11, 7, 20, 14, 1, 12, 8, 10, 2, 6, 13, 17,
        };

        public static Task<int[]> SortAsync(int[] randomNumbers)
        {
            return Task.Factory.StartNew(
                () =>
                {
                    var newArray = CreateNewArray(randomNumbers);
                    bool swap;
                    Thread.Sleep(1000);

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
                });
        }

        static void Main(string[] args)
        {
            bool first = true;
            var rand = new Random();

            while (true)
            {
                Console.Write(alphabet[rand.Next(0, 26)]);

                if (first)
                {
                    first = false;
                    Start();
                }
                Thread.Sleep(200);
            }

            Console.ReadKey();
        }

        private async static void Start()
        {
            var sth = await SortAsync(randomItems);
            Console.WriteLine(string.Join("_", sth));
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