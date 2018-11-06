using System;

namespace LinqTest
{
    public class User
    {
        public User(string firstName, string lastName, string address = "Szczecin", string posiotion = "admin", decimal age = 21)
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

        public decimal Age { get; private set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }

    }
}