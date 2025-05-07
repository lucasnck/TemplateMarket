namespace TemplateMarket.Application.Responses;

public record CompanyResponse(
    long Id,
    string Name,
    EntityResponse Entity
);