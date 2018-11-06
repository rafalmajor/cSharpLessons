using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventsSortUnitTests
{
    [TestClass]
    public class EventSortUnitTest
    {
        private readonly int[] randomItems = { 16, 4, 19, 5, 15, 3, 18, 9, 11, 7, 20, 14, 1, 12, 8, 10, 2, 6, 13, 17 };

        private readonly int[] sortedItems = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        [TestMethod]
        public void BubbleSortTest()
        {
            var bubbleSort = new BubbleSort();
            bubbleSort.Done += BubbleSortOnDone;
            bubbleSort.Input = this.randomItems;
            bubbleSort.Sort();
        }

        [TestMethod]
        public void InsertSortTest()
        {
            var insertSort = new InsertSort();
            insertSort.Done += (s, a) =>
            {
                CollectionAssert.AreEqual(this.sortedItems, ((ISort)s).Output);
            };
            insertSort.Input = this.randomItems;
            insertSort.Sort();
        }

        [TestMethod]
        public void QuickSortTest()
        {
            var quickSort = new QuickSort();
            quickSort.Done += delegate(object sender, EventArgs args)
            {
                CollectionAssert.AreEqual(this.sortedItems, ((ISort)sender).Output);
            };
            quickSort.Input = this.randomItems;
            quickSort.Sort();
        }

        private void BubbleSortOnDone(object sender, EventArgs e)
        {
            CollectionAssert.AreEqual(this.sortedItems, ((ISort)sender).Output);
        }

    }
}