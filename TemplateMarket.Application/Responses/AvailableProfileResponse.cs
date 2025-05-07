namespace TemplateMarket.Application.Responses;

public record AvailableProfileResponse(
    IEnumerable<ProfileResponse> Profiles,
    ActiveProfileResponse ActiveProfile
);
