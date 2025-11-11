using System.Globalization;

namespace airbnb_c_.Domain.ValueObjects
{
    public sealed class Name
    {
        public string FirstName { get; }
        public string LastName { get; }

        private Name() { } //EF core

        public Name(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException("First name is mandatory.");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentNullException("Last name is mandatory.");

            firstName = firstName.Trim();
            lastName = lastName.Trim();
        }

        public override string ToString() => $"{FirstName} {LastName}";

        public override bool Equals(object? obj)
        {
            if (obj is not Name other) return false;
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode() => HashCode.Combine(FirstName, LastName);
    }
}
