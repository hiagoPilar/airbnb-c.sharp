

namespace airbnb_c_.Domain.ValueObjects
{
    public class Password
    {
        public string Value { get; } = null!;

        private Password() { }

        public Password(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Password is mandatory.");

            if (value.Length < 8)
                throw new ArgumentException("The password must contain at least 8 characters.");

            Value = value;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Password other) return false;
            return Value == other.Value;
        }

        public override int GetHashCode() => Value.GetHashCode();

    }
}
