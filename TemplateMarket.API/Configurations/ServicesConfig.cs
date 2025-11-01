using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TemplateMarket.Application.Common.Behaviors;
using TemplateMarket.Application.Common.Integration;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Application.Common.Services;
using TemplateMarket.Application.Mappings;
using TemplateMarket.Application.UseCases.Products.Commands;
using TemplateMarket.Application.UseCases.Products.Validators;
using TemplateMarket.Infrastructure.Persistence;
using TemplateMarket.Infrastructure.Persistence.Repositories;

namespace TemplateMarket.API.Configurations;

public static class ServicesConfig
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseLazyLoadingProxies()
                   .UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IRepository), typeof(Repository));
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IActiveProfileService, ActiveProfileService>();
        services.AddScoped<IEmailNotification, EmailNotification>();
        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
        services.AddScoped<IGroupTemplateService, GroupTemplateService>();
        services.AddScoped<ICacheService, CacheService>();

        services.AddMediatR(typeof(CreateProductCommandHandler).Assembly);
        services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);
        services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AuthCommandEnricherBehavior<,>));

        services.AddSingleton<IIntegrationEventPublisher, InMemoryIntegrationEventPublisher>();
        services.AddHostedService<IntegrationEventBackgroundWorker>();

        services.AddIntegrationEventHandlers(typeof(UserCreateConfirmationTokenEventHandler).Assembly);


        services.AddHttpContextAccessor();
        services.AddHttpClient();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
        });

        return services;
    }
}
