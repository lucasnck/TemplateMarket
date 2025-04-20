namespace TemplateMarket.Domain.Entities;

public class TemplatePlatform : BaseEntity
{
    public long TemplateId { get; set; }
    public Template Template { get; set; } = default!;

    public long PlatformId { get; set; }
    public Platform Platform { get; set; } = default!;
}
