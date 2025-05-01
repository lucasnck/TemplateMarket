using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class ShowcaseProduct : BaseEntity
{
    public long ProductId { get; set; }
    public Product Product { get; set; }

    public long ShowcaseId { get; set; }
    public Showcase Showcase { get; set; }

    public ShowcaseProduct() { }

}
