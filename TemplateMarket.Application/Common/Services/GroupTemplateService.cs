using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Common.Services;

public class GroupTemplateService(IRepository _repo) : IGroupTemplateService
{

    public IEnumerable<long> GetGroupIdsForTemplates(IEnumerable<string> templateKeys)
    {
        return _repo.Query<GroupTemplate>()
            .Where(t => templateKeys.Contains(t.TemplateKey))
            .SelectMany(gt => gt.Groups.Select(g => g.Id))
            .Distinct()
            .ToList();
    }
}