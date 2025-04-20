namespace TemplateMarket.Application.UseCases.Platforms.Dtos;

public class CreatePlatformDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string LogoUrl { get; set; } = default!;
}
