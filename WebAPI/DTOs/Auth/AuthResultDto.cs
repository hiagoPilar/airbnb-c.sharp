namespace WebAPI.DTOs.Auth
{
    public class AuthResultDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string UserName { get; set; } = default!;
    }
}
