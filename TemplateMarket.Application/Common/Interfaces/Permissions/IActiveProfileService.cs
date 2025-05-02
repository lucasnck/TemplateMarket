namespace TemplateMarket.Application.Common.Interfaces.Permissions;

public interface IActiveProfileService
{
    long UserId { get; }
    string Email { get; }

    Task<long?> GetCompanyIdAsync();
    Task<bool> IsCompanyAsync();

    Task<List<string>> GetRolesAsync();
    Task<List<string>> GetGroupsAsync();
}
