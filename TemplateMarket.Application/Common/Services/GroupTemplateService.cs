using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Common.Services;

public class GroupTemplateService(IRepository<UserGroupTemplate> _templateRepo) : IGroupTemplateService
{
    public async Task<List<long>> GetGroupIdsForTemplateAsync(string templateKey)
    {
        var groups = await _templateRepo.FindAsync(t => t.TemplateKey == templateKey);
        return groups.Select(t => t.GroupId).ToList();
    }
}