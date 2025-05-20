namespace TemplateMarket.Application.Common.Interfaces.Permissions;

public interface IGroupTemplateService
{
    IEnumerable<long> GetGroupIdsForTemplateAsync(string templateKey);
}