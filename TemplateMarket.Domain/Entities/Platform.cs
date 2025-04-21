namespace TemplateMarket.Domain.Entities;

public class Platform : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string LogoUrl { get; set; } = default!;
    public bool IsActive { get; set; } = true;

    public virtual ICollection<TemplatePlatform> TemplatePlatforms { get; set; } = new List<TemplatePlatform>();
}
