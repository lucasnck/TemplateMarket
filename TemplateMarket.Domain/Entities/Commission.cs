namespace TemplateMarket.Domain.Entities;

public class Commission : BaseEntity
{
    public long PartnerId { get; set; }
    public Partner Partner { get; set; } = default!;
    public long OrderItemId { get; set; }
    public OrderItem OrderItem { get; set; } = default!;
    public decimal Percentage { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
}
