namespace TemplateMarket.Application.Common.Interfaces.Permissions;

public interface IGroupTemplateService
{
    Task<List<long>> GetGroupIdsForTemplateAsync(string templateKey);
}