using MediatR;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Application.Responses;

namespace TemplateMarket.Application.UseCases.Auth.Queries;

public record GetSelfProfilesQuery : IRequest<AvailableProfileResponse>;

public class GetAvailableProfilesQueryHandler(
    IActiveProfileService _activeProfile
) : IRequestHandler<GetSelfProfilesQuery, AvailableProfileResponse>
{
    public async Task<AvailableProfileResponse> Handle(GetSelfProfilesQuery request, CancellationToken ct)
    {
        return await _activeProfile.GetCurrentProfile();
    }
}
