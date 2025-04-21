namespace TemplateMarket.Application.Responses
{
    public class TemplateResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public string Theme { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ThumbnailUrl { get; set; } = string.Empty;

        public IEnumerable<PlatformResponse> Platforms { get; set; }
        public IEnumerable<CategoryResponse> Categories { get; set; }
    }
}
