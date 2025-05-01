using AutoMapper;
using TemplateMarket.Application.Mappings.Extensions;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.Products.Commands;
using TemplateMarket.Application.UseCases.Products.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Mappings;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductResponse>()
          .ForMember(d => d.Categories,
                     o => o.MapFrom(src =>
                         src.ProductCategories.Select(tc => tc.Category)));

        CreateMap<CreateProductDto, Product>()
           .ForMember(dest => dest.ProductCategories,
                opt => opt.MapFrom(src => src.CategoryIds.Select(id => new ProductCategory { CategoryId = id })));

        CreateMap<UpdateProductDto, Product>()
           .ForMember(dest => dest.ProductCategories,
                opt => opt.MapFrom(src => src.CategoryIds.Select(id => new ProductCategory { CategoryId = id })))
            .ApplyBaseUpdateRules<UpdateProductDto, Product>()
            .ForNullableBool(d => d.IsActive);

        CreateMap<UpdateProductCommand, Product>()
            .IncludeBase<UpdateProductDto, Product>();
    }
}
