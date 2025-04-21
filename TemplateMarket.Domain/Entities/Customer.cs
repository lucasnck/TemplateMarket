namespace TemplateMarket.Domain.Entities;

public class Customer
{
    public long Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Phone { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
