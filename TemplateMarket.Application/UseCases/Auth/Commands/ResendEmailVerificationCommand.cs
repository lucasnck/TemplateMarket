using MediatR;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Interfaces.Permissions;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Auth.Commands;
public record ResendEmailVerificationCommand() : IRequest;

public class ResendEmailVerificationCommandHandler(
    IRepository _repo,
    IEmailNotification _emailNotification,
    IActiveProfileService _activeProfileService
) : IRequestHandler<ResendEmailVerificationCommand>
{
    public async Task<Unit> Handle(ResendEmailVerificationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _activeProfileService.GetUser();

            if (user.IsEmailVerified)
                throw new Exception("E-mail já verificado.");

            user.EmailVerificationToken = Guid.NewGuid().ToString();
            user.EmailVerificationTokenExpiresAt = DateTime.UtcNow.AddHours(24);

            string verificationUrl = $"https://seusite.com/verify-email?token={user.EmailVerificationToken}";

            await _repo.SaveChangesAsync();

            await _emailNotification.SendNotificationAsync(
                user.Email,
                "Verifique seu e-mail",
                "EMAIL",
                $"Clique no link para verificar seu e-mail: {verificationUrl}"
            );
        }
        catch (Exception ex)
        {
            // log exception
        }

        return Unit.Value;
    }
}
