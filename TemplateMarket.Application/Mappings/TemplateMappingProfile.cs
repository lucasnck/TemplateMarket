using AutoMapper;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Mappings;

public class TemplateMappingProfile : Profile
{
    public TemplateMappingProfile()
    {
        CreateMap<Template, TemplateResponse>().ReverseMap();
    }
}
