namespace TemplateMarket.Application.UseCases.Platforms.Dtos;

public class UpdatePlatformDto
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
    public bool? IsActive { get; set; }
}
