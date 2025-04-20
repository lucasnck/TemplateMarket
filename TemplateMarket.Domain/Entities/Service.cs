namespace TemplateMarket.Domain.Entities;

public class Service : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<ServiceCategory> ServiceCategories { get; set; } = new List<ServiceCategory>();
}
