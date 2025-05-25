namespace TemplateMarket.Application.UseCases.GroupTemplates.Dtos;

public class UpdateGroupTemplateDto
{
    public long? Id { get; set; }
    public string TemplateKey { get; set; }
    public IEnumerable<long> GroupIds { get; set; }
}
