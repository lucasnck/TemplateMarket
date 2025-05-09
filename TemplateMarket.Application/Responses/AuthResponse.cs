namespace TemplateMarket.Application.Responses;

public class AuthResponse
{
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Identification { get; set; }
    public bool IsEmailVerified { get; set; }
    public string? Token { get; set; }

    public AuthResponse()
    {
    }
};