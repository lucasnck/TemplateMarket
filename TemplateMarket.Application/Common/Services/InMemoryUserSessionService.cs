using TemplateMarket.Application.Common.Interfaces.Permissions;

namespace TemplateMarket.Application.Common.Services.InMemory;

public class InMemoryUserSessionService : IUserSessionService
{
    private readonly Dictionary<long, long?> _map = new();

    public Task<long?> GetActiveCompanyIdAsync(long userId)
    {
        _map.TryGetValue(userId, out var companyId);
        return Task.FromResult(companyId);
    }

    public Task SetActiveCompanyIdAsync(long userId, long companyId)
    {
        _map[userId] = companyId;
        return Task.CompletedTask;
    }
}
