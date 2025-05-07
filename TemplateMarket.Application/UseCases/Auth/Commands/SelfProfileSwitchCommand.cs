using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Auth.Commands;

public record SelfProfileSwitchCommand(long? CompanyId) : IRequest<AvailableProfileResponse>;

public class SelfProfileSwitchCommandHandler(
    IActiveProfileService _activeProfile,
    IRepository _repo
    //ICacheService _cacheService
) : IRequestHandler<SelfProfileSwitchCommand, AvailableProfileResponse>
{
    public async Task<AvailableProfileResponse> Handle(SelfProfileSwitchCommand request, CancellationToken cancellationToken)
    {
        //var cacheKey = $"active-profile:{_activeProfile.UserId}:CompanyId";
        //var value = request.CompanyId?.ToString();
        //await _cacheService.SetValueAsync(cacheKey, value);

        await _activeProfile.SetActiveProfile(request.CompanyId);

        await _repo.SaveChangesAsync();

        return await _activeProfile.GetCurrentProfile();
    }
}

