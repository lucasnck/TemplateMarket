namespace TemplateMarket.Application.UseCases.UserGroups.Dtos;

public class UserGroupDto
{
    public long UserId { get; set; }
    public IEnumerable<long> GroupIds { get; set; }
}