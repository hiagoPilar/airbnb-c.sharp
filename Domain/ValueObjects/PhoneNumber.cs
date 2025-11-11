using System.Text.RegularExpressions;

namespace airbnb_c_.Domain.ValueObjects
{
    public sealed class PhoneNumber
    {
        public string Number { get; } = null!;

        private PhoneNumber() { }

        public PhoneNumber(string number)
        {
            if(string.IsNullOrWhiteSpace(number))
                throw new ArgumentNullException("Phone number is mandatory.");

            var cleaned = Regex.Replace(number, @"[^\d]", "");
            if (cleaned.Length > 10)
                throw new ArgumentException("Invalid phone number");

            Number = cleaned;
        }

        public override string ToString() => Number;

        public override bool Equals(object? obj)
        {
            if (obj is not PhoneNumber other) return false;
            return Number == other.Number;
        }

        public override int GetHashCode() => Number.GetHashCode();

        
    }
}
