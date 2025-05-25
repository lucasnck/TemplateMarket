namespace TemplateMarket.Application.UseCases.GroupTemplates.Dtos;

public class CreateGroupTemplateDto
{
    public string TemplateKey { get; set; }
    public IEnumerable<long> GroupIds { get; set; }
}
