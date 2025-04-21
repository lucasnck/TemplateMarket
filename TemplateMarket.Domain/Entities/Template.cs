namespace TemplateMarket.Domain.Entities
{
    public class Template : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string PreviewUrl { get; set; } = default!;
        public string ThumbnailUrl { get; set; } = default!;

        public virtual ICollection<TemplatePlatform> TemplatePlatforms { get; set; } = new List<TemplatePlatform>();
        public virtual ICollection<TemplateCategory> TemplateCategories { get; set; } = new List<TemplateCategory>();
    }
}
