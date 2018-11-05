using System;

namespace GeneralSortUnitTests
{
    public class User : IComparable<User>
    {
        public string LastName { get; private set; }

        public string FirstName { get; private set; }

        public string Address { get; private set; }

        public string Posiotion { get; private set; }

        public UInt16 Age { get; private set; }

        public int CompareTo(User other)
        {
            int value = this.LastName.CompareTo(other.LastName);

            if (value != 0)
            {
                return value;
            }

            return this.FirstName.CompareTo(other.LastName);
        }
    }
}