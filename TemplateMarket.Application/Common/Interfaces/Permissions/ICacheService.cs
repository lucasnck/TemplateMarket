namespace TemplateMarket.Application.Common.Interfaces.Permissions;

public interface ICacheService
{
    Task<string?> GetValueAsync(string key);
    Task SetValueAsync(string key, string? value);
}
