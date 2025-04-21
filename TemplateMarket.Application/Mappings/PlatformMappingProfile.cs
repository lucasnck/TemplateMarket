using AutoMapper;
using TemplateMarket.Application.Mappings.Extensions;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.Platforms.Commands;
using TemplateMarket.Application.UseCases.Platforms.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Mappings;

public class PlatformMappingProfile : Profile
{
    public PlatformMappingProfile()
    {
        CreateMap<Platform, PlatformResponse>()
            .ReverseMap();

        CreateMap<CreatePlatformDto, Platform>();

        CreateMap<UpdatePlatformDto, Platform>()
            .ForMember(dest => dest.Id, o => o.Ignore())
            .ForMember(dest => dest.CreatedDate, o => o.Ignore())
            .ForMember(dest => dest.UpdatedDate, o => o.Ignore())

            .ForNullableBool(d => d.IsActive)

            .ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) => srcMember != null)
            );

        CreateMap<UpdatePlatformCommand, Platform>()
            .IncludeBase<UpdatePlatformDto, Platform>();
    }
}
