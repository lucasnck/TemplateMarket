using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TemplateMarket.Application.Common.Interfaces.Permissions;

namespace TemplateMarket.Application.Common.Services;

public class ActiveProfileService(
    IHttpContextAccessor _httpContext,
    IPermissionResolver _permissionResolver,
    IUserSessionService _sessionService
) : IActiveProfileService
{
    public long UserId => long.Parse(_httpContext.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
    public string Email => _httpContext.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value!;

    public async Task<bool> IsCompanyAsync()
    {
        var companyId = await GetCompanyIdAsync();
        return companyId != null;
    }

    public Task<long?> GetCompanyIdAsync()
        => _sessionService.GetActiveCompanyIdAsync(UserId);

    public async Task<List<string>> GetRolesAsync()
    {
        var companyId = await GetCompanyIdAsync();
        return await _permissionResolver.ResolveRolesAsync(UserId, companyId);
    }

    public async Task<List<string>> GetGroupsAsync()
    {
        var companyId = await GetCompanyIdAsync();
        return await _permissionResolver.ResolveGroupsAsync(UserId, companyId);
    }
}
