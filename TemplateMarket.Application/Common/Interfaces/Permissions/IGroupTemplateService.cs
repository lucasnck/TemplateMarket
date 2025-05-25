namespace TemplateMarket.Application.Common.Interfaces.Permissions;

public interface IGroupTemplateService
{
    IEnumerable<long> GetGroupIdsForTemplates(IEnumerable<string> templateKeys);
}