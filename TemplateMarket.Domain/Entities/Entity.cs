using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Enums;

namespace TemplateMarket.Domain.Entities;

public class Entity : BaseEntity
{
    public string Name { get; set; }
    public string Identification { get; set; } // CPF ou CNPJ
    public EntityType Type { get; set; } // Enum: Individual ou Company

    public Entity(string name, string identification, EntityType type)
    {
        Name = name;
        Identification = identification;
        Type = type;
    }

    // Para o EF Core
    private Entity() { }
}
