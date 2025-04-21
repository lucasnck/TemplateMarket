using AutoMapper;
using TemplateMarket.Application.UseCases.Service.Dto;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Mappings
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<CreateServiceDto, Service>();
            CreateMap<UpdateServiceDto, Service>();
        }
    }
}
