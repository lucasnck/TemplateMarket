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

    public virtual ICollection<Template> Templates { get; set; } = new List<Template>();
    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
    public virtual ICollection<Commission> Commissions { get; set; } = new List<Commission>();
    public virtual ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
}
