namespace TemplateMarket.Application.Responses;

public record AuthResponse(
    long UserId,
    string Email,
    string? Token
);