namespace TemplateMarket.Application.UseCases.Products.Dtos;

public class UpdateProductDto
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Theme { get; set; }
    public decimal? Price { get; set; }
    public string? PreviewUrl { get; set; }
    public string? ThumbnailUrl { get; set; }
    public string? Description { get; set; }
    public bool? IsActive { get; set; }

    public List<long> PlatformIds { get; set; } = new();
    public List<long> CategoryIds { get; set; } = new();
}
