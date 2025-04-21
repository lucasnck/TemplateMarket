using AutoMapper;
using TemplateMarket.Application.Mappings.Extensions;
using TemplateMarket.Application.Responses;
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
                opt => opt.MapFrom(src => src.PlatformIds.Select(id => new TemplatePlatform { PlatformId = id })));

        CreateMap<CreateTemplateDto, Template>().ReverseMap();

        CreateMap<UpdateTemplateDto, Template>()
            .ForMember(dest => dest.Id, o => o.Ignore())
            .ForMember(dest => dest.CreatedDate, o => o.Ignore())
            .ForMember(dest => dest.UpdatedDate, o => o.Ignore())

            .ForNullableDecimal(d => d.Price)

            // aplica regra para todos os outros campos nullable
            .ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) => srcMember != null)
            );

        // inclui o mapeamento do Command → Entidade (herda do DTO)
        CreateMap<UpdateTemplateCommand, Template>()
            .IncludeBase<UpdateTemplateDto, Template>();
    }
}
