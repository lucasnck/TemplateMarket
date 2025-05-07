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
        user.Role = "Customer";
        user.PasswordHash = passwordHash;
        user.Entity = entity;

        await _repo.AddAsync(user);

        var token = _tokenGenerator.GenerateToken(user);

        await _repo.SaveChangesAsync();

        user.AddDomainEvent(new CustomerCreatedDomainEvent(user.Id));

        return new AuthResponse(user.Id, user.Email, token);
    }
}
