using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Auth.Commands.ChangePassword;

public record ChangePasswordCommand(string CurrentPassword, string NewPassword) : IRequest;

public class ChangePasswordCommandHandler(
    IHttpContextAccessor _httpContextAccessor,
    IActiveProfileService _activeProfile,
    IRepository _repo
) : IRequestHandler<ChangePasswordCommand>
{
    public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken ct)
    {
        var user = await _repo.SingleOrThrow<User>(x => x.Id == _activeProfile.UserId)
                   ?? throw new NotFoundException(nameof(User));

        if (!BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.PasswordHash))
            throw new UnauthorizedAccessException("Senha atual incorreta.");

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        await _repo.SaveChangesAsync();

        return Unit.Value;
    }
}
