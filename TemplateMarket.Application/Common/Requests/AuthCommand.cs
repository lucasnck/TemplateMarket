namespace TemplateMarket.Application.Common.Requests;

public abstract class AuthCommand : IAuthCommand
{
    public long UserId { get; set; }
    public string? Role { get; set; }
    public string? Email { get; set; }
}
