using AutoMapper;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, AuthResponse>()
                .ForMember(dst => dst.Identification, opt => opt.MapFrom(src => src.Entity.Identification))
                .ForMember(dst => dst.IsEmailVerified, opt => opt.MapFrom(src => src.IsEmailVerified))
                .ReverseMap();

            CreateMap<RegisterUserCommand, User>();
        }
    }
}
