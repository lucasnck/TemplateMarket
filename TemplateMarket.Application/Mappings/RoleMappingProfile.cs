using AutoMapper;
using TemplateMarket.Application.UseCases.Roles.Commands;
using TemplateMarket.Application.UseCases.Roles.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Mappings;

public class RoleMappingProfile : Profile
{
    public RoleMappingProfile()
    {
        CreateMap<RoleDto, Role>();
        CreateMap<CreateRoleCommand, Role>()
            .IncludeBase<RoleDto, Role>();
    }
}
