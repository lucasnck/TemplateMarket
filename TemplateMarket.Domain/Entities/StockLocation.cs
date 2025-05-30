using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Common.Interfaces;

namespace TemplateMarket.Domain.Entities;

public class StockLocation : BaseEntity, IActivable
{
    public string Name { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; }
}
