using TemplateMarket.Application.Common.Interfaces.Permissions;
using Microsoft.Extensions.Caching.Distributed;

namespace TemplateMarket.Application.Common.Services;

public class RedisUserSessionService : IUserSessionService
{
    private readonly IDistributedCache _cache;
    private readonly TimeSpan _ttl = TimeSpan.FromHours(1);

    public RedisUserSessionService(IDistributedCache cache)
    {
        _cache = cache;
    }

    private string GetKey(long userId) => $"session:active-company:{userId}";

    public async Task<long?> GetActiveCompanyIdAsync(long userId)
    {
        var value = await _cache.GetStringAsync(GetKey(userId));
        return long.TryParse(value, out var companyId) ? companyId : null;
    }

    public async Task SetActiveCompanyIdAsync(long userId, long companyId)
    {
        await _cache.SetStringAsync(GetKey(userId), companyId.ToString(), new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = _ttl
        });
    }
}
