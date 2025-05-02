using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMarket.Application.Responses;
using TemplateMarket.Application.UseCases.Platforms.Commands;
using TemplateMarket.Application.UseCases.Platforms.Dtos;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Mappings;

public class EntityMappingProfile : Profile
{
    public EntityMappingProfile()
    {
        CreateMap<RegisterUserCommand, Entity>()
            .ReverseMap();
    }
}