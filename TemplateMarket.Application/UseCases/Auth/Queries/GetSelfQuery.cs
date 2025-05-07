using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Auth.Queries.GetSelf;

public record GetSelfQuery : IRequest<AuthResponse>;

public class GetSelfQueryHandler(
    IActiveProfileService _activeProfile,
    IRepository _repo
) : IRequestHandler<GetSelfQuery, AuthResponse>
{
    public async Task<AuthResponse> Handle(GetSelfQuery request, CancellationToken ct)
    {
        var user = await _repo.GetByIdAsync<User>(_activeProfile.UserId);

        return new AuthResponse(
            _activeProfile.UserId,
            user.Email,
            null
        );
    }
}
