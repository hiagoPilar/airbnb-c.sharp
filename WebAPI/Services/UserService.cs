using airbnb_c_.Domain.Entities;
using airbnb_c_.Domain.Enums;
using airbnb_c_.Domain.Interfaces;
using airbnb_c_.Domain.ValueObjects;
using AutoMapper;
using WebAPI.DTOs.User;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            
            if(createUserDto == null)
                throw new ArgumentNullException(nameof(createUserDto));
            
            var user = new User(
                new Name(createUserDto.FirstName, createUserDto.LastName),
                new Email(createUserDto.Email),
                new Password(createUserDto.Password),
                new PhoneNumber(createUserDto.PhoneNumber),
                role: UserRole.Guest
               
            );

            if(!string.IsNullOrEmpty(createUserDto.Bio))
                user.UpdateBio(createUserDto.Bio);

            if(!string.IsNullOrEmpty(createUserDto.ProfilePictureUrl))
                user.ChangeProfilePictureUrl(createUserDto.ProfilePictureUrl);

            if(!string.IsNullOrEmpty(createUserDto.Language))
                user.SetLanguage(createUserDto.Language);

            await _userRepository.AddAsync(user);
            return _mapper.Map<UserDto>(user);

        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return false;
            await _userRepository.DeleteAsync(user);
            return true;

        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetByIdAsync(updateUserDto.Id);

            if (user == null)
                throw new Exception("User not found!");

            //name
            if(!string.IsNullOrEmpty(updateUserDto.FirstName) && !string.IsNullOrEmpty(updateUserDto.LastName))
            {
                var newName = new Name(
                    updateUserDto.FirstName.Trim(),
                    updateUserDto.LastName.Trim()
                );
                user.UpdateName(newName);
            }

            //phone
            if (!string.IsNullOrEmpty(updateUserDto.PhoneNumber))
            {
                var phone = new PhoneNumber(updateUserDto.PhoneNumber);
                user.ChangePhoneNumber(phone);
            }

            //profilePicture
            if(updateUserDto.ProfilePictureUrl != null)
            {
                user.ChangeProfilePictureUrl(
                    string.IsNullOrWhiteSpace(updateUserDto.ProfilePictureUrl)
                    ? null
                    : updateUserDto.ProfilePictureUrl.Trim()
                );
            }

            //bio
            if(updateUserDto.Bio != null)
            {
                user.UpdateBio(updateUserDto.Bio.Trim());
            }

            //language
            if(updateUserDto.Language != null)
            {
                user.SetLanguage(updateUserDto.Language.Trim());
            }

            await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserDto>(user);

        }
    }
}

