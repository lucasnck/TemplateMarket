using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Common.Interfaces;

namespace TemplateMarket.Domain.Entities;

public class Category : BaseEntity, IActivable
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public bool IsActive { get; set; } = true;

    public virtual ICollection<TemplateCategory> TemplateCategories { get; set; } = new List<TemplateCategory>();
    public virtual ICollection<ServiceCategory> ServiceCategories { get; set; } = new List<ServiceCategory>();
}
