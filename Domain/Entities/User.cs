using airbnb_c_.Domain.Enums;
using airbnb_c_.Domain.ValueObjects;
namespace airbnb_c_.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public Password Password { get; private set; } = null!;
        public PhoneNumber PhoneNumber { get; private set; } = null!;
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
        public DateTime? UpdatedAt { get; private set; }


        //private constructor for ORM
        private User() 
        {

        }

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
            UpdatedAt = DateTime.UtcNow;
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

        public void ChangePassword(Password newPassword)
        {
            Password = newPassword ?? throw new ArgumentNullException(nameof(newPassword));
            UpdatedAt = DateTime.UtcNow;
        }

        public void EnableTwoFactor(TwoFactorType type)
        {
            TwoFactorEnabled = true;
            TwoFactorType = type;
            UpdatedAt = DateTime.UtcNow;
        }

        public void DisableTwoFactor()
        {
            TwoFactorEnabled = false;
            TwoFactorType = null;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPasswordResetToken(string token, DateTime expiration)
        {
            PasswordResetToken = token;
            PasswordResetTokenExpiration = expiration;
            UpdatedAt = DateTime.UtcNow;
        }

        public void CleanPasswordResetToken()
        {
            PasswordResetToken = null;
            PasswordResetTokenExpiration = null;
            UpdatedAt = DateTime.UtcNow;
        }

        public void VerifyEmail()
        {
            IsEmailVerified = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Activate()
        {
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
