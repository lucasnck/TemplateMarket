using TemplateMarket.API.Filters;

namespace TemplateMarket.API.Configurations;

public static class MiddlewareConfig
{
    public static IServiceCollection AddApiMiddlewares(this IServiceCollection services)
    {
        services.AddScoped<RoleFilter>();
        services.AddScoped<ActiveProfileValidationMiddleware>();

        services.AddControllers(options =>
        {
            options.Filters.Add<ApiExceptionFilter>();
            options.Filters.Add<ResultResponseFilter>();
            options.Filters.Add<RoleFilter>();
        });

        return services;
    }
}
