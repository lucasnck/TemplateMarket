using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class Customer : BaseEntity
{
    public long Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Phone { get; set; }

    public long EntityId { get; set; }
    public virtual Entity Entity { get; set; }

    public long? UserId { get; set; }
    public virtual User? User { get; set; }

    public long? CompanyId { get; set; }
    public virtual Company? Company { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
