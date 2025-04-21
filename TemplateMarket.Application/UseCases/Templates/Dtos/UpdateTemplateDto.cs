namespace TemplateMarket.Application.UseCases.Templates.Dtos;

public class UpdateTemplateDto
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }

    public List<long> PlatformIds { get; set; } = new();
}
