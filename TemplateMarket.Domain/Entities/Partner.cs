namespace TemplateMarket.Domain.Entities;

public enum PartnerType { Agency, Designer, Developer }

public class Partner : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public PartnerType Type { get; set; }
    public string? PortfolioUrl { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Template> Templates { get; set; } = new List<Template>();
    public ICollection<Service> Services { get; set; } = new List<Service>();
    public ICollection<Commission> Commissions { get; set; } = new List<Commission>();
    public ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
}
