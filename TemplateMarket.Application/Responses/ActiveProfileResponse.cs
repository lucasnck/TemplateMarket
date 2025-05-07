namespace TemplateMarket.Application.Responses;

public record ActiveProfileResponse(
    string Name,
    string Identification,
    string Type,
    DateTime CreatedDate,
    IEnumerable<string> Roles
);
