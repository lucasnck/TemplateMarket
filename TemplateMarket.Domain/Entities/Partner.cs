using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Common.Interfaces;
using TemplateMarket.Domain.Enums;

namespace TemplateMarket.Domain.Entities;

public class Partner : BaseEntity, IActivable
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public PartnerType Type { get; set; }
    public string? PortfolioUrl { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual ICollection<Product> Products { get; set; } = [];
    public virtual ICollection<ServiceDetail> Services { get; set; } = [];
    public virtual ICollection<Commission> Commissions { get; set; } = [];
    public virtual ICollection<WorkOrder> WorkOrders { get; set; } = [];
}
