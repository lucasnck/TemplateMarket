using TemplateMarket.Application.Common.Exceptions;

namespace TemplateMarket.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            Result<object> result = null;
            if (ex is DomainException)
            {
                context.Response.StatusCode = 400;
                result = new Result<object>
                {
                    Success = false,
                    Errors = new[] { ex.Message }
                };
            }
            else
            {
                context.Response.StatusCode = 500;
                result = new Result<object>
                {
                    Success = false,
                    Errors = new[] { "Internal server error." }
                };
            }

            await context.Response.WriteAsJsonAsync(result);
        }
    }
}
