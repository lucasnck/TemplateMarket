using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using TemplateMarket.Application.Common.Integration;

public static class IntegrationEventHandlerRegistrationExtensions
{
    public static void AddIntegrationEventHandlers(this IServiceCollection services, Assembly assembly)
    {
        var handlerInterfaceType = typeof(IDomainEventHandler<>);

        var handlers = assembly.GetTypes()
            .Where(t => !t.IsAbstract && !t.IsInterface)
            .SelectMany(t => t.GetInterfaces(), (t, i) => new { Type = t, Interface = i })
            .Where(x => x.Interface.IsGenericType && x.Interface.GetGenericTypeDefinition() == handlerInterfaceType)
            .ToList();

        foreach (var handler in handlers)
        {
            services.AddScoped(handler.Interface, handler.Type);
        }
    }
}
