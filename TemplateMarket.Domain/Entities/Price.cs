using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Common.Interfaces;
using TemplateMarket.Domain.Enums;

namespace TemplateMarket.Domain.Entities;

public class Price : BaseEntity, IActivable
{
    public decimal Value { get; set; }
    public PriceType PriceType { get; set; }
    public bool IsActive { get; set; }
}
