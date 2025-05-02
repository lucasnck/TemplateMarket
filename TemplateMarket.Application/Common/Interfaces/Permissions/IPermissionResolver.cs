namespace TemplateMarket.Application.Common.Interfaces.Permissions;

public interface IPermissionResolver
{
    Task<List<string>> ResolveRolesAsync(long userId, long? companyId = null);
    Task<List<string>> ResolveGroupsAsync(long userId, long? companyId = null);
}
