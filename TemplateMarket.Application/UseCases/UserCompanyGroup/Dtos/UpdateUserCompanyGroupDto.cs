namespace TemplateMarket.Application.UseCases.UserCompanyGroup.Dtos;

public class UpdateUserCompanyGroupDto
{
    public long UserId { get; set; }
    public long CompanyId { get; set; }
    public IEnumerable<long> GroupIds { get; set; } = [];
}
