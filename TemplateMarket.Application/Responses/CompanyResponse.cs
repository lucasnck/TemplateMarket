namespace TemplateMarket.Application.Responses;

public record CompanyResponse(
    long Id,
    string Name,
    string Identification,
    string Type // "CPF" ou "CNPJ"
);