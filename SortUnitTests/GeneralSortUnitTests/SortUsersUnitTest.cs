using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneralSortUnitTests
{
    [TestClass]
    public class SortUsersUnitTest
    {
        private readonly User[] randomUsers =
        {
            new User("Jan", "Nowak "),
            new User("Zbigniew", "Wójcik"),
            new User("Stanisław", "Nowak "),
            new User("Henryk", "Kamiński"),
            new User("Andrzej", "Nowak"),
            new User("Józef", "Kowalski"),
            new User("Jerzy", "Wiśniewski"),
            new User("Tadeusz", "Kowalski"),
            new User("Krzysztof", "Kowalczyk"),
        };

        private readonly User[] sortedUsers =
        {
            new User("Henryk", "Kamiński"),
            new User("Krzysztof", "Kowalczyk"),
            new User("Józef", "Kowalski"),
            new User("Tadeusz", "Kowalski"),
            new User("Andrzej", "Nowak"),
            new User("Jan", "Nowak "),
            new User("Stanisław", "Nowak "),
            new User("Jerzy", "Wiśniewski"),
            new User("Zbigniew", "Wójcik"),
        };

        [TestMethod]
        public void BubbleSortTest()
        {
            var sorted = BubbleSort.Sort(this.randomUsers);
            CollectionAssert.AreEqual(sorted, this.sortedUsers);
        }

        [TestMethod]
        public void InsertSortTest()
        {
            var sorted = InsertSort.Sort(this.randomUsers);
            CollectionAssert.AreEqual(sorted, this.sortedUsers);
        }

        [TestMethod]
        public void QuickSortTest()
        {
            var sorted = QuickSort.Sort(this.randomUsers);
            CollectionAssert.AreEqual(sorted, this.sortedUsers);
        }
    }
}