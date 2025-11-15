using airbnb_c_.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs.User
{
    public class UpdateRoleDto
    {
        public Guid UserId { get; set; }

        [Required]
        public UserRole NewRole { get; set; }
    }
}
