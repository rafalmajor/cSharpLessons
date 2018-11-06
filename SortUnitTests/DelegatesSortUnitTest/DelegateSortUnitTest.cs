using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegatesSortUnitTest
{
    [TestClass]
    public class DelegateSortUnitTest
    {
        private readonly int[] randomItems = { 16, 4, 19, 5, 15, 3, 18, 9, 11, 7, 20, 14, 1, 12, 8, 10, 2, 6, 13, 17 };

        private readonly int[] sortedItems = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        [TestMethod]
        public void DelegatesExamples()
        {
            Action DoNothingAction1 = this.DoNothing;
            Action DoNothingAction2 = () => { };

            Action<int> ProcessIntAction1 = this.ProcessInt;
            Action<int> ProcessIntAction2 = (number) =>
            {
                int sum = 0;

                for (int i = 0; i < number; i++)
                {
                    sum += i;
                }
            };

            Func<bool> RetrunTrueFunc1 = this.RetrunTrue;
            Func<bool> RetrunTrueFunc2 = () => true;

            Func<int, bool> ProcessIntFunc1 = ProcessIntAndReturnResult;
            Func<int, bool> ProcessIntFunc2 = (number) =>
            {
                int sum = 0;

                for (int i = 0; i < number; i++)
                {
                    sum += i;
                }

                return sum > 0;
            };
        }

        [TestMethod]
        public void TestBubbleSortAsDelegate()
        {
            Func<int[], int[]> func = Sort.Bubble;

            var sorted = func(this.randomItems);

            CollectionAssert.AreEqual(this.sortedItems, sorted);
        }

        private bool ProcessIntAndReturnResult(int number)
        {
            int sum = 0;

            for (int i = 0; i < number; i++)
            {
                sum += i;
            }

            return sum > 0;
        }

        private bool RetrunTrue()
        {
            return true;
        }



        [TestMethod]
        public void TestAll()
        {
        }

        public void DoNothing()
        {
        }

        private void ProcessInt(int number)
        {
            int sum = 0;

            for (int i = 0; i < number; i++)
            {
                sum += i;
            }
        }
    }
}
