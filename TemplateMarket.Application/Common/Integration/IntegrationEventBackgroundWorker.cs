using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TemplateMarket.Application.Common.Integration;

public class IntegrationEventBackgroundWorker(
    ILogger<IntegrationEventBackgroundWorker> _logger,
    IServiceScopeFactory _scopeFactory
) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("IntegrationEventBackgroundWorker running.");

        while (!stoppingToken.IsCancellationRequested)
        {
            if (InMemoryIntegrationEventPublisher.TryDequeue(out var integrationEvent))
            {
                await ProcessEventAsync(integrationEvent);
            }
            else
            {
                await Task.Delay(500, stoppingToken);
            }
        }
    }

    private async Task ProcessEventAsync(IDomainEvent integrationEvent)
    {
        using var scope = _scopeFactory.CreateScope();

        var serviceProvider = scope.ServiceProvider;

        var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(integrationEvent.GetType());

        var handlers = serviceProvider.GetServices(handlerType);

        foreach (var handler in handlers)
        {
            var method = handlerType.GetMethod("HandleAsync");
            var task = (Task)method.Invoke(handler, new object[] { integrationEvent });
            await task;
        }

        if (!handlers.Any())
        {
            _logger.LogWarning("No handlers found for integration event type {EventType}", integrationEvent.GetType().Name);
        }
    }
}
