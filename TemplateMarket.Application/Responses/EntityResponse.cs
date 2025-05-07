namespace TemplateMarket.Application.Responses;

public record EntityResponse(
    long Id,
    string Name,
    string Identification,
    string Type // "CPF" ou "CNPJ"
);