using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Auth.Queries.GetSelf;

public record GetSelfQuery() : IRequest<AuthResponse>;

public class GetSelfQueryHandler(
    IHttpContextAccessor _httpContext,
    IRepository<User> _repository
) : IRequestHandler<GetSelfQuery, AuthResponse>
{
    public async Task<AuthResponse> Handle(GetSelfQuery request, CancellationToken ct)
    {
        var userId = _httpContext.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                     ?? throw new UnauthorizedAccessException();

        var user = await _repository.GetByIdAsync(long.Parse(userId))
                   ?? throw new NotFoundException("User", userId);

        return new AuthResponse(user.Id, user.Email, user.Role, null);
    }
}
