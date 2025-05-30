using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class Stock : BaseEntity
{
    public int Quantity { get; set; }
    public int QuantityReserved { get; set; }
    public int Available { get; set; }

    public long ProductId { get; set; }
    public virtual Product Product { get; set; }

    public long StockLocationId { get; set; }
    public virtual StockLocation StockLocation { get; set; }

    public virtual ICollection<StockUnit> StockUnits { get; set; }
}

