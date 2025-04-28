using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Common.Interfaces;

namespace TemplateMarket.Domain.Entities
{
    public class Template : BaseEntity, IActivable
    {
        public string Name { get; set; } = default!;
        public string Theme { get; set; }
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string PreviewUrl { get; set; } = default!;
        public string ThumbnailUrl { get; set; } = default!;
        public bool IsActive { get; set; } = true;

        public long? PartnerId { get; set; }
        public virtual Partner? Partner { get; set; }


        public virtual ICollection<TemplatePlatform> TemplatePlatforms { get; set; } = new List<TemplatePlatform>();
        public virtual ICollection<TemplateCategory> TemplateCategories { get; set; } = new List<TemplateCategory>();
    }
}
