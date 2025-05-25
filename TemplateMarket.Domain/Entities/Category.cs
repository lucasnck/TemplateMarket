using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Common.Interfaces;
using TemplateMarket.Domain.Enums;

namespace TemplateMarket.Domain.Entities;

public class Category : BaseEntity, IActivable
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public bool IsActive { get; set; } = true;

    public long? ParentCategoryId { get; set; }
    public virtual Category? ParentCategory { get; set; }    

    public long? PlatformId { get; set; }
    public virtual Platform? Platform { get; set; }
    
    public virtual ICollection<Product> Products { get; set; } = [];
}
