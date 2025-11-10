using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace airbnb_c_.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public UserRole Role { get; private set; }
        public bool IsEmailVerified { get; private set; }
        public bool IsActive { get; private set; }
        public string? ProfilePictureUrl { get; private set; }
        public string? Bio { get; private set; }
        public string? Language { get; private set; }
        public bool TwoFactorEnabled { get; private set; }
        public TwoFactorType? TwoFactorType { get; private set; }
        public string? PasswordResetToken { get; private set; }
        public DateTime? PasswordResetTokenExpiration { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }


        //private constructor for ORM
        private User() { }

        //main contructor 
        public User(Name name, Email email, Password password, PhoneNumber phoneNumber, UserRole role)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Role = role;
            IsActive = true;
            IsEmailVerified = false;
            CreatedAt = DateTime.UtcNow;
        }

        //bussines rules
        public void UpdateProfile(Name name, PhoneNumber phone, string? profilePictureUrl = null, string? bio = null, string? language = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PhoneNumber = phone;
            ProfilePictureUrl = profilePictureUrl;
            Bio = bio;
            Language = language;
            UpdatedAt = DateTime.UtcNow;
        }

        public void changePassword(Password newPassword)
        {
            Password = newPassword ?? throw new ArgumentNullException(nameof(newPassword));
            UpdatedAt = DateTime.UtcNow;
        }

        public void enableTwoFactor(TwoFactorType)

    }
}
