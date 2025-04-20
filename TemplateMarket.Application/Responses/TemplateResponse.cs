namespace TemplateMarket.Application.Responses
{
    public class TemplateResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public string Theme { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ThumbnailUrl { get; set; } = string.Empty;
    }
}
