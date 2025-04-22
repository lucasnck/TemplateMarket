using AutoMapper;
using TemplateMarket.Application.Mappings.Extensions;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.Categories.Commands;
using TemplateMarket.Application.UseCases.Category.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryResponse>().ReverseMap();
        CreateMap<CreateCategoryDto, Category>();

        CreateMap<UpdateCategoryDto, Category>()
            .ForNullableBool(d => d.IsActive)
            .ApplyBaseUpdateRules<UpdateCategoryDto, Category>();

        CreateMap<UpdateCategoryCommand, Category>()
            .IncludeBase<UpdateCategoryDto, Category>();
    }
}
