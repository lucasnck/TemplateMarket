using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TemplateMarket.Application.Common.Requests;

namespace TemplateMarket.Application.Common.Behaviors;

public class AuthCommandEnricherBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : AuthCommand, IRequest<TResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthCommandEnricherBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user?.Identity?.IsAuthenticated == true)
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (long.TryParse(userId, out var id))
                request.UserId = id;

            request.Email = user.FindFirst(ClaimTypes.Email)?.Value;
            request.Role = user.FindFirst(ClaimTypes.Role)?.Value;
        }

        return await next();
    }
}
