namespace TemplateMarket.Domain.Entities
{
    public class Template
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string PreviewUrl { get; set; } = default!;
        public string ThumbnailUrl { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<TemplatePlatform> TemplatePlatforms { get; set; } = new List<TemplatePlatform>();
    }
}
