using airbnb_c_.Domain.Enums;

namespace WebAPI.DTOs.User
{
    public class CreateUserDto
    {
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
        public string? Language { get; set; }
    }
}
