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
                .ReverseMap();

            CreateMap<RegisterUserCommand, User>();
        }
    }
}
