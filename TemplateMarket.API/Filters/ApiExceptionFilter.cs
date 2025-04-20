using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TemplateMarket.Application.Common.Exceptions;

namespace TemplateMarket.API.Filters;

public class ApiExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ApiExceptionFilter> _logger;

    public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "Unhandled exception");

        var exception = context.Exception;

        ObjectResult result;

        switch (exception)
        {
            case AppValidationException validationException:
                result = new ObjectResult(new
                {
                    Title = "Validation Failed",
                    Errors = validationException.Errors
                })
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
                break;

            case NotFoundException notFoundException:
                result = new ObjectResult(new
                {
                    Title = "Not Found",
                    Detail = notFoundException.Message
                })
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
                break;

            case FluentValidation.ValidationException fluentValidationException:
                result = new ObjectResult(new
                {
                    Title = "Validation Failed",
                    Errors = fluentValidationException.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Select(e => e.ErrorMessage).ToArray()
                        )
                })
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
                break;

            default:
                result = new ObjectResult(new
                {
                    Title = "An unexpected error occurred.",
                    Detail = exception.Message
                })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                break;
        }

        context.Result = result;
        context.ExceptionHandled = true;
    }
}
