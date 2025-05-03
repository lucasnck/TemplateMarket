using MediatR;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Application.Responses;

namespace TemplateMarket.Application.UseCases.Auth.Queries.GetSelf;

public record GetSelfQuery : IRequest<AuthResponse>;

public class GetSelfQueryHandler(
    IActiveProfileService _activeProfile
) : IRequestHandler<GetSelfQuery, AuthResponse>
{
    public async Task<AuthResponse> Handle(GetSelfQuery request, CancellationToken ct)
    {
        var roles = await _activeProfile.GetRolesAsync();
        var groups = await _activeProfile.GetGroupsAsync();

        return new AuthResponse(
            _activeProfile.UserId,
            _activeProfile.Email
        );
    }
}
