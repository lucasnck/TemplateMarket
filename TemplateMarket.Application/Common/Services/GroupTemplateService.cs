using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Common.Services;

public class GroupTemplateService(IRepository _repo) : IGroupTemplateService
{
    public List<long> GetGroupIdsForTemplateAsync(string templateKey)
    {
        var groups = _repo.Query<UserGroupTemplate>().Where(t => t.TemplateKey == templateKey);
        return groups.Select(t => t.GroupId).ToList();
    }
}