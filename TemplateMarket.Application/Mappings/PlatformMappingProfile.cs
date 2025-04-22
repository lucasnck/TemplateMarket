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
            .ApplyBaseUpdateRules<UpdatePlatformDto, Platform>();

        CreateMap<UpdatePlatformCommand, Platform>()
            .IncludeBase<UpdatePlatformDto, Platform>();
    }
}
