namespace TemplateMarket.Application.Responses;

public record ProfileResponse(
    string Name,
    string Identification,
    string Type,
    DateTime CreatedDate
);
