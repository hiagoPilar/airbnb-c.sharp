using System.Text.RegularExpressions;

namespace airbnb_c_.Domain.ValueObjects
{
    public sealed class PhoneNumber
    {
        public string Number { get; }

        private PhoneNumber() { }

        public PhoneNumber(string number)
        {
            if(string.IsNullOrWhiteSpace(number))
                throw new ArgumentNullException("Phone number is mandatory.");

            var cleaned = Regex.Replace(number, @"[^\d]", "");
            if (cleaned.Length > 10)
                throw new ArgumentException("Invalid phone number");
        }

        
    }
}
