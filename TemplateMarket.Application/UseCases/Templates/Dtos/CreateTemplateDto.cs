namespace TemplateMarket.Application.UseCases.Templates.Dtos;

public class CreateTemplateDto
{
    public string Name { get; set; } = string.Empty;
    public string Theme { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string PreviewUrl { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    public List<long> PlatformIds { get; set; } = new();

    public List<long> CategoryIds { get; set; } = new();
}