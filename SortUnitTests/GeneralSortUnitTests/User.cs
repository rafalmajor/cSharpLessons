using System;
using System.Linq;

namespace GeneralSortUnitTests
{
    public class User : IComparable<User>, IEquatable<User>
    {
        public User(string firstName, string lastName, string address = "Szczecin", string posiotion = "admin", uint age = 21)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.Posiotion = posiotion;
            this.Age = age;
        }

        public string LastName { get; private set; }

        public string FirstName { get; private set; }

        public string Address { get; private set; }

        public string Posiotion { get; private set; }

        public uint Age { get; private set; }

        public int CompareTo(User other)
        {
            int value = this.LastName.CompareTo(other.LastName);

            if (value != 0)
            {
                return value;
            }

            return this.FirstName.CompareTo(other.LastName);
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }

        public bool Equals(User other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(this.LastName, other.LastName) && string.Equals(this.FirstName, other.FirstName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.LastName != null ? this.LastName.GetHashCode() : 0) * 397) ^ (this.FirstName != null ? this.FirstName.GetHashCode() : 0);
            }
        }
    }
}