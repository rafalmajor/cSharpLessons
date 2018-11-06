using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqTest
{
    [TestClass]
    public class LinqUnitTest
    {
        private readonly User[] randomUsers =
        {
            new User("Jan", "Nowak", "Szczecin", "dev", 22),
            new User("Zbigniew", "Wójcik", "Stargard", "admin", 23),
            new User("Stanisław", "Nowak", "Szczecin", "dev", 26),
            new User("Henryk", "Kamiński", "Gorzów", "admin", 28),
            new User("Andrzej", "Nowak", "Stargard", "dev", 20),
            new User("Józef", "Kowalski", "Szczecin", "admin", 50),
            new User("Jerzy", "Wiśniewski", "Stargard", "dev", 12),
            new User("Tadeusz", "Kowalski", "Gorzów", "admin", 24),
            new User("Krzysztof", "Kowalczyk", "Stargard", "dev", 22),
        };

        [TestMethod]
        public void WhereTest()
        {
            var selectedUsers1 = this.randomUsers.Where(user => user.LastName == "Nowak");

            var selectedUsers2 = from user in this.randomUsers
                where user.LastName == "Nowak" select user;

            CollectionAssert.AreEqual(selectedUsers1.ToArray(), selectedUsers2.ToArray());
        }

        [TestMethod]
        public void GroupTest()
        {
            var groupUsers1 = this.randomUsers.GroupBy(user => user.LastName);
            var groupUsers2 = from user in this.randomUsers group user by user.LastName;

            CollectionAssert.AreEqual(groupUsers1.Select(u =>u.Key).ToArray(), groupUsers2.Select(u => u.Key).ToArray());
        }

        [TestMethod]
        public void OrderByTest()
        {
            var orderUser1 = this.randomUsers.OrderBy(user => user.LastName).ThenBy(user => user.FirstName);
            var orderUser2 = from user in this.randomUsers
                orderby user.LastName, user.FirstName select user;

            CollectionAssert.AreEqual(orderUser1.ToArray(), orderUser2.ToArray());
        }

        [TestMethod]
        public void SelectTest()
        {
            var select1 = this.randomUsers.Select(user => $"{user.FirstName} {user.LastName}, age{user.Age}");
            var select2 = from user in this.randomUsers
                select $"{user.FirstName} {user.LastName}, age{user.Age}";

            CollectionAssert.AreEqual(select1.ToArray(), select2.ToArray());
        }



        [TestMethod]
        public void SelectTwoTest()
        {
            var select1 = this.randomUsers.Select(user => new Cat(user.LastName));
            var select2 = from user in this.randomUsers
                select new Cat(user.LastName);

            CollectionAssert.AreEqual(select1.ToArray(), select2.ToArray());
        }

        [TestMethod]
        public void MinTest()
        {
            var min1 = this.randomUsers.Min(user => user.Age);
            var min2 = (from user in this.randomUsers
                select user.Age).Min();

            Assert.AreEqual(min1, min2);
        }

        [TestMethod]
        public void MaxTest()
        {
            var max1 = this.randomUsers.Max(user => user.Age);
            var max2 = (from user in this.randomUsers
                select user.Age).Max();

            Assert.AreEqual(max1, max2);
        }

        [TestMethod]
        public void SumTest()
        {
            var sum1 = this.randomUsers.Sum(user => user.Age);
            var sum2 = (from user in this.randomUsers
                select user.Age).Sum();

            Assert.AreEqual(sum1, sum2);
        }

        [TestMethod]
        public void SelectManyTest()
        {

        }

        [TestMethod]
        public void AggegateTest()
        {

        }

        [TestMethod]
        public void AnyTest()
        {
            var emptyList = new List<User>();
            Assert.IsFalse(emptyList.Any());
            Assert.IsTrue(this.randomUsers.Any());
            Assert.IsFalse(this.randomUsers.Any(user => user.Age > 100));
            Assert.IsTrue(this.randomUsers.Any(user => user.Age > 30));
        }

        [TestMethod]
        public void AllTest()
        {
            var emptyList = new List<User>();
            Assert.IsTrue(emptyList.All(user => user.Age > 10));
            Assert.IsTrue(this.randomUsers.All(user => user.Age > 10));
            Assert.IsFalse(this.randomUsers.All(user => user.Age > 20));
        }

        private class Cat
        {
            public Cat(string ownerLastName)
            {
                this.OwnerLastName = ownerLastName;
            }

            public string OwnerLastName { get; }

            public override string ToString()
            {
                return $"Owner:{this.OwnerLastName}";
            }
        }
    }
}
