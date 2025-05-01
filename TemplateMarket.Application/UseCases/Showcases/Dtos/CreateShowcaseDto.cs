namespace TemplateMarket.Application.UseCases.Showcases.Dtos;

public class CreateShowcaseDto
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
}
