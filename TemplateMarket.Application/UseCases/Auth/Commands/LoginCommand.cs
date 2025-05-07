using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<string>;

public class LoginCommandHandler(
    IRepository _repo,
    IJwtTokenGenerator _tokenGenerator
) : IRequestHandler<LoginCommand, string>
{
    public Task<string> Handle(LoginCommand request, CancellationToken ct)
    {
        var user = _repo.Query<User>().FirstOrDefault(u => u.Email == request.Email)
                   ?? throw new UnauthorizedAccessException("Credenciais inválidas.");

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Credenciais inválidas.");

        var token = _tokenGenerator.GenerateToken(user);
        return Task.FromResult(token);
    }
}
