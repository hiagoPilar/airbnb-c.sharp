using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs.User
{
    public class UpdateEmailDto
    {
        public Guid UserId { get; set; }

        [Required]
        [EmailAddress]
        public string NewEmail { get; set; } = null!;

        public string PasswordConfirmation { get; set; } = null!;
    }
}
