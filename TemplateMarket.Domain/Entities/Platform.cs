using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Common.Interfaces;

namespace TemplateMarket.Domain.Entities;

public class Platform : BaseEntity, IActivable
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string LogoUrl { get; set; } = default!;
    public bool IsActive { get; set; } = true;

    public long CategoryId { get; set; }
    public virtual Category Category { get; set; }
}
