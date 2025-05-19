using AutoMapper;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Mappings;

public class EntityMappingProfile : Profile
{
    public EntityMappingProfile()
    {
        CreateMap<RegisterUserCommand, Entity>()
            .ReverseMap();
    }
}