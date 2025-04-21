using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Domain.Entities;

public class TemplatePlatform : BaseEntity
{
    public long TemplateId { get; set; }
    public virtual Template Template { get; set; } = default!;

    public long PlatformId { get; set; }
    public virtual Platform Platform { get; set; } = default!;
}
