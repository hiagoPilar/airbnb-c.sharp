using System.Text.RegularExpressions;

namespace airbnb_c_.Domain.ValueObjects
{
    public sealed class Email
    {
        public string Address { get; } = null!;

        private Email() { }

        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException("Email is mandatory.");
            if (!Regex.IsMatch(address, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Invalid email.");

            Address = address.Trim().ToLowerInvariant();
        }

        public override string ToString() => Address;

        public override bool Equals(object? obj)
        {
            if(obj is not Email other) return false;
            return Address == other.Address;
        }

        public override int GetHashCode() => Address.GetHashCode();
    }
}
