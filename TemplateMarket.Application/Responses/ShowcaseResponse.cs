using TemplateMarket.Application.Responses;

namespace TemplateMarket.Application.UseCases.Showcases.Dtos;

public class ShowcaseResponse
{
    public long Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }

    public IEnumerable<ProductResponse> Products { get; set; }
}
