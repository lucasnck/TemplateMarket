using TemplateMarket.Application.Responses;

namespace TemplateMarket.Application.Common.Interfaces.Permissions;

public interface IActiveProfileService
{
    long UserId { get; }

    Task<AvailableProfileResponse> GetCurrentProfile();

    Task SetActiveProfile(long? CompanyId);
}
