using System;
using System.Threading.Tasks;

namespace BackgroudTasks
{
    class Program
    {
        public async static Task StartTask(int index)
        {
            await SortAsync(index).ConfigureAwait(true);
        }

        public static Task SortAsync(int index)
        {
            return Task.Factory.StartNew(
                () => { Console.WriteLine($"Task {index}"); });
        }

        static void Main(string[] args)
        {
            for (int i = 1; i < 11; i++)
            {
                StartTask(i);
            }

            Console.WriteLine("End of Hello World!");
        }
    }
}