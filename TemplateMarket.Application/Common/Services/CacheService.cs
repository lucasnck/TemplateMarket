using TemplateMarket.Application.Common.Interfaces.Permissions;
using Microsoft.Extensions.Caching.Distributed;

namespace TemplateMarket.Application.Common.Services;

public class CacheService : ICacheService
{
    private readonly IDistributedCache _cache;
    private readonly TimeSpan _ttl = TimeSpan.FromHours(1);

    public CacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    private string GetKey(string key) => $"cache:{key}";

    public async Task<string?> GetValueAsync(string key)
    {
        var value = await _cache.GetStringAsync(GetKey(key));
        return value;
    }

    public async Task SetValueAsync(string key, string? value)
    {
        await _cache.SetStringAsync(GetKey(key), value, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = _ttl
        });
    }
}
