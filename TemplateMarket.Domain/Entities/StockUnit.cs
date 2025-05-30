using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Enums;

namespace TemplateMarket.Domain.Entities;

public class StockUnit : BaseEntity
{
    public int Quantity { get; set; }
    public StockUnitType Type { get; set; }
    public StockUnitReference Reference { get; set; }


    public long StocktId { get; set; }
    public virtual Stock Stock { get; set; }

    public long OrderItemId { get; set; }
    public virtual OrderItem OrderItem { get; set; }
}
