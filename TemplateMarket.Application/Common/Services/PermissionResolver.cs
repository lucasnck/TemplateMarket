using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Common.Services;

public class PermissionResolver(
    IRepository<UserGroup> _userGroupRepo,
    IRepository<UserCompanyGroup> _userCompanyGroupRepo,
    IRepository<GroupRole> _groupRoleRepo,
    IRepository<Role> _roleRepo
) : IPermissionResolver
{
    public async Task<List<string>> ResolveGroupsAsync(long userId, long? companyId = null)
    {
        if (companyId.HasValue)
        {
            var entries = await _userCompanyGroupRepo.FindAsync(x => x.UserId == userId && x.CompanyId == companyId);
            return entries.Select(x => x.Group.Name).Distinct().ToList();
        }
        else
        {
            var entries = await _userGroupRepo.FindAsync(x => x.UserId == userId);
            return entries.Select(x => x.Group.Name).Distinct().ToList();
        }
    }

    public async Task<List<string>> ResolveRolesAsync(long userId, long? companyId = null)
    {
        List<long> groupIds;

        if (companyId.HasValue)
        {
            var entries = await _userCompanyGroupRepo.FindAsync(x => x.UserId == userId && x.CompanyId == companyId);
            groupIds = entries.Select(x => x.GroupId).ToList();
        }
        else
        {
            var entries = await _userGroupRepo.FindAsync(x => x.UserId == userId);
            groupIds = entries.Select(x => x.GroupId).ToList();
        }

        var groupRoles = await _groupRoleRepo.FindAsync(gr => groupIds.Contains(gr.GroupId));
        var roleIds = groupRoles.Select(gr => gr.RoleId).Distinct().ToList();

        var roles = await _roleRepo.FindAsync(r => roleIds.Contains(r.Id));
        return roles.Select(r => r.Name).Distinct().ToList();
    }
}