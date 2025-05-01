namespace TemplateMarket.Application.UseCases.Showcases.Dtos;

public class UpdateShowcaseDto
{
    public long Id { get; set; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public List<string> Skus { get; init; } = [];
}
