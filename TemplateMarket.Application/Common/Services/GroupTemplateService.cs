using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Common.Services;

public class GroupTemplateService(IRepository _repo) : IGroupTemplateService
{
    public IEnumerable<long> GetGroupIdsForTemplateAsync(string templateKey)
    {
        var groupTemplates = _repo.Query<GroupTemplate>()
            .Where(t => t.TemplateKey == templateKey);

        return groupTemplates
            .SelectMany(gt => gt.Groups.Select(g => g.Id));
    }
}