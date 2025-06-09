namespace TemplateMarket.Application.Common.Integration;

public interface IDomainEvent
{
    Guid EventId { get; }
    DateTime OccurredOn { get; }
}