using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

public record RegisterUserCommand(
    string identification,
    string Name,
    string Email,
    string Phone,
    string Password
) : IRequest<AuthResponse>;

public class RegisterUserCommandHandler(
    IRepository _repo,
    IMapper _mapper,
    IJwtTokenGenerator _tokenGenerator
) : IRequestHandler<RegisterUserCommand, AuthResponse>
{
    public async Task<AuthResponse> Handle(RegisterUserCommand request, CancellationToken ct)
    {
        if (_repo.Query<User>().Any(u => u.Entity.Identification == request.identification))
            throw new AlreadyExistsException(nameof(User));

        // Hash da senha fora da entidade
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var entity = _mapper.Map<Entity>(request);
        entity.Name = request.Name;
        entity.Type = TemplateMarket.Domain.Enums.EntityType.Individual;

        var user = _mapper.Map<User>(request);
        user.PasswordHash = passwordHash;
        user.Entity = entity;
        
        // Gere um token de verificação único (simples)
        user.EmailVerificationToken = Guid.NewGuid().ToString();
        user.EmailVerificationTokenExpiresAt = DateTime.UtcNow.AddHours(24); // expira em 24h

        await _repo.AddAsync(user);

        var token = _tokenGenerator.GenerateToken(user);

        user.AddDomainEvent(new UserCreatedDomainEvent(user));
        await _repo.SaveChangesAsync();

        var response = _mapper.Map<AuthResponse>(user);
        response.Token = token;

        return response;
    }
}
