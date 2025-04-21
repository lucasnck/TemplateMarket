namespace TemplateMarket.Application.UseCases.Platforms.Dtos;

public class UpdatePlatformDto
{
    public long Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string LogoUrl { get; set; } = default!;
    public bool IsActive { get; set; }
}
