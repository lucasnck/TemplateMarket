using TemplateMarket.Domain.Enums;

namespace TemplateMarket.Application.UseCases.Entities.Dtos;

public class EntityDto
{
    public string Name { get; set; }
    public string Identification { get; set; }
    public EntityType Type { get; set; }
}
