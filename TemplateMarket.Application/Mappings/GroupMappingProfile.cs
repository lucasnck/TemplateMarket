using AutoMapper;
using TemplateMarket.Application.UseCases.Groups.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Mappings;

public class GroupMappingProfile : Profile
{
    public GroupMappingProfile()
    {
        CreateMap<GroupDto, Group>();
    }
}
