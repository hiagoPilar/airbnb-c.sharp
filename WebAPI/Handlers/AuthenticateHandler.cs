using airbnb_c_.Domain.Interfaces;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Handlers
{
    public class AuthenticateHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwt;
    }
}
