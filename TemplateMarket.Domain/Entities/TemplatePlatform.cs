namespace TemplateMarket.Domain.Entities;

public class TemplatePlatform
{
    public Guid TemplateId { get; set; }
    public Template Template { get; set; } = default!;

    public Guid PlatformId { get; set; }
    public Platform Platform { get; set; } = default!;
}
