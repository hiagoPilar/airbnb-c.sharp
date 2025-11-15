namespace WebAPI.DTOs.User
{
    public class ReadUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Role { get; set; } = null!;
        public bool IsEmailVerified { get; set; }
        public bool IsActive { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
        public string? Language { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string? TwoFactorType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
