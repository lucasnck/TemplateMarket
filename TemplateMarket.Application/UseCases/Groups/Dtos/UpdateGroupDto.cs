namespace TemplateMarket.Application.UseCases.Groups.Dtos;

public class UpdateGroupDto
{
    public long Id { get; set; }
    public string Description { get; set; }
    public IEnumerable<long> RoleIds { get; set; }
}