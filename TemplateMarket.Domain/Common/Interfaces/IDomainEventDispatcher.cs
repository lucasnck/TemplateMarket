using MediatR;
using TemplateMarket.Domain.Common.Entities;

public interface IDomainEventDispatcher
{
    Task DispatchEventsAsync(IEnumerable<BaseEntity> entities, CancellationToken cancellationToken);
}

public class DomainEventDispatcher(IMediator mediator) : IDomainEventDispatcher
{
    public async Task DispatchEventsAsync(IEnumerable<BaseEntity> entities, CancellationToken ct)
    {
        foreach (var entity in entities)
        {
            var domainEvents = entity.DomainEvents.ToList();
            entity.ClearDomainEvents();

            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent, ct);
            }
        }
    }
}