using AutoMapper;
using MediatR;
using TemplateMarket.Application.Common.Integration;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Responses;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

public record RegisterUserCommand(
    string Identification,
    string Name,
    string Email,
    string Phone,
    string Password
) : IRequest<AuthResponse>;

public class RegisterUserCommandHandler(
    IRepository _repo,
    IMapper _mapper,
    IIntegrationEventPublisher _integrationEventPublisher,
    IJwtTokenGenerator _tokenGenerator
) : IRequestHandler<RegisterUserCommand, AuthResponse>
{
    public async Task<AuthResponse> Handle(RegisterUserCommand request, CancellationToken ct)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var entity = _mapper.Map<Entity>(request);
        entity.Name = request.Name;
        entity.Type = TemplateMarket.Domain.Enums.EntityType.Individual;

        var user = _mapper.Map<User>(request);
        user.PasswordHash = passwordHash;
        user.Entity = entity;

        user.EmailVerificationToken = Guid.NewGuid().ToString();
        user.EmailVerificationTokenExpiresAt = DateTime.UtcNow.AddHours(24);

        await _repo.AddAsync(user);
        await _repo.SaveChangesAsync();

        var response = _mapper.Map<AuthResponse>(user);
        var token = _tokenGenerator.GenerateToken(user);
        response.Token = token;

        await _integrationEventPublisher.PublishAsync(new UserCreatedDomainEvent(user.Id));

        return response;
    }
}
