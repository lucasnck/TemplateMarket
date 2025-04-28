namespace TemplateMarket.Application.Responses
{
    public record AuthResponse(
        long Id,
        string Email,
        string Role,
        string Token
    );
}
