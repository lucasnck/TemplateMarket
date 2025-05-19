namespace TemplateMarket.Application.UseCases.Groups.Dtos;

public class GroupDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<long> RoleIds { get; set; }
}