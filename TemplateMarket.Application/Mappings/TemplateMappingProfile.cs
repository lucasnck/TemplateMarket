using AutoMapper;
using TemplateMarket.Application.Mappings.Extensions;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.Category.Dtos;
using TemplateMarket.Application.UseCases.Templates.Commands;
using TemplateMarket.Application.UseCases.Templates.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Mappings;

public class TemplateMappingProfile : Profile
{
    public TemplateMappingProfile()
    {
        CreateMap<Template, TemplateResponse>()
          .ForMember(d => d.Platforms,
                     o => o.MapFrom(src =>
                         src.TemplatePlatforms.Select(tp => tp.Platform)))
          .ForMember(d => d.Categories,
                     o => o.MapFrom(src =>
                         src.TemplateCategories.Select(tc => tc.Category)));

        CreateMap<CreateTemplateDto, Template>()
           .ForMember(dest => dest.TemplatePlatforms,
                opt => opt.MapFrom(src => src.PlatformIds.Select(id => new TemplatePlatform { PlatformId = id })))
           .ForMember(dest => dest.TemplateCategories,
                opt => opt.MapFrom(src => src.CategoryIds.Select(id => new TemplateCategory { CategoryId = id })));

        CreateMap<UpdateTemplateDto, Template>()
           .ForMember(dest => dest.TemplatePlatforms,
                opt => opt.MapFrom(src => src.PlatformIds.Select(id => new TemplatePlatform { PlatformId = id })))
           .ForMember(dest => dest.TemplateCategories,
                opt => opt.MapFrom(src => src.CategoryIds.Select(id => new TemplateCategory { CategoryId = id })))
            .ApplyBaseUpdateRules<UpdateTemplateDto, Template>()
            .ForNullableDecimal(d => d.Price)
            .ForNullableBool(d => d.IsActive);

        CreateMap<UpdateTemplateCommand, Template>()
            .IncludeBase<UpdateTemplateDto, Template>();
    }
}
