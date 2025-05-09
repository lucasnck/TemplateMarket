using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Application.Responses;

namespace TemplateMarket.Application.UseCases.Auth.Commands;

public record SelfProfileSwitchCommand(string? CompanyIdentification) : IRequest<AvailableProfileResponse>;

public class SelfProfileSwitchCommandHandler(
    IActiveProfileService _activeProfile,
    IRepository _repo
) : IRequestHandler<SelfProfileSwitchCommand, AvailableProfileResponse>
{
    public async Task<AvailableProfileResponse> Handle(SelfProfileSwitchCommand request, CancellationToken cancellationToken)
    {
        _activeProfile.SetActiveProfile(request.CompanyIdentification);

        await _repo.SaveChangesAsync();

        return await _activeProfile.GetCurrentProfile();
    }
}

