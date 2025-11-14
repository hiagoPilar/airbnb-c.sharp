using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs.User
{
    public class UpdatePasswordDto
    {
        public Guid UserId { get; set; }

        [Required]
        public string CurrentPassword { get; set; } = null!;

        [Required]
        [MinLength(8)]
        public string NewPassword { get; set; } = null!;
    }
}
