using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class ShowcaseProduct : BaseEntity
{
    public long ProductId { get; set; }
    public virtual Product Product { get; set; }

    public long ShowcaseId { get; set; }
    public virtual Showcase Showcase { get; set; }

    public ShowcaseProduct() { }

}
