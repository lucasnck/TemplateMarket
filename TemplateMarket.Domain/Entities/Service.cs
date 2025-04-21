using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Common.Interfaces;

namespace TemplateMarket.Domain.Entities;

public class Service : BaseEntity, IActivable
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual ICollection<ServiceCategory> ServiceCategories { get; set; } = new List<ServiceCategory>();
}
