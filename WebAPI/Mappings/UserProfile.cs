using airbnb_c_.Domain.Entities;
using AutoMapper;
using WebAPI.DTOs.User;

namespace WebAPI.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, ReadUserDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToString()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Address))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber.Number))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
                .ForMember(dest => dest.TwoFactorType, opt => opt.MapFrom(src => src.TwoFactorType != null ? src.TwoFactorType.ToString() : null));
        }
    }
}
