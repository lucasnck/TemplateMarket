using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.Common.Interfaces.Permissions;

public interface IActiveProfileService
{
    long? TryGetUserId();

    Task<User> GetUser();

    Task<AvailableProfileResponse> GetCurrentProfile();

    void SetActiveProfile(string? companyIdentification);
}
