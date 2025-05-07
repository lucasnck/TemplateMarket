namespace TemplateMarket.Application.Common.Interfaces.Permissions;

public interface IGroupTemplateService
{
    List<long> GetGroupIdsForTemplateAsync(string templateKey);
}