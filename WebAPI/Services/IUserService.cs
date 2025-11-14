using WebAPI.DTOs.User;

namespace WebAPI.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> UpdateUserAsync(UpdateUserDto updateUserDto);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
