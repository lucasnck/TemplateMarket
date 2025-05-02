namespace TemplateMarket.Application.Common.Interfaces.Permissions;

public interface IUserSessionService
{
    Task<long?> GetActiveCompanyIdAsync(long userId);
    Task SetActiveCompanyIdAsync(long userId, long companyId);
}
