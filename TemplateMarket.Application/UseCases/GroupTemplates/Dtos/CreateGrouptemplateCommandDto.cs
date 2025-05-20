namespace TemplateMarket.Application.UseCases.GroupTemplates.Dtos;

public class CreateGrouptemplateCommandDto
{
    public string TemplateKey { get; set; }
    public IEnumerable<long> GroupIds { get; set; }
}
