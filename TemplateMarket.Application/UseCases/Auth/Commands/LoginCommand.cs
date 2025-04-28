using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<AuthResponse>;

public class LoginCommandHandler(
    IRepository<User> _repository,
    IJwtTokenGenerator _tokenGenerator
) : IRequestHandler<LoginCommand, AuthResponse>
{
    public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken ct)
    {
        var user = await _repository.SingleOrDefaultAsync(u => u.Email == request.Email)
                   ?? throw new UnauthorizedAccessException("Credenciais inválidas.");

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Credenciais inválidas.");

        var token = _tokenGenerator.GenerateToken(user);
        return new AuthResponse(user.Id, user.Email, user.Role, token);
    }
}
