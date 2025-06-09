using System.Collections.Concurrent;

namespace TemplateMarket.Application.Common.Integration;

public interface IIntegrationEventPublisher
{
    Task PublishAsync(IDomainEvent integrationEvent);
}

public class InMemoryIntegrationEventPublisher : IIntegrationEventPublisher
{
    private static readonly ConcurrentQueue<IDomainEvent> _queue = new();

    public Task PublishAsync(IDomainEvent integrationEvent)
    {
        _queue.Enqueue(integrationEvent);
        return Task.CompletedTask;
    }

    public static bool TryDequeue(out IDomainEvent integrationEvent)
    {
        return _queue.TryDequeue(out integrationEvent);
    }
}
