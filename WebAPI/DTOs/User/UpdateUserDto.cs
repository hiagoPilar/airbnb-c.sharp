namespace WebAPI.DTOs.User
{
    public class UpdateUserDto
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
        public string? Language { get; set; }
    }
}
