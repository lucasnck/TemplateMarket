using Microsoft.Extensions.Logging;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Integration;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

public class UserCreateConfirmationTokenEventHandler(
    IRepository _repo,
    IEmailNotification _emailNotification,
    ILogger<UserCreateConfirmationTokenEventHandler> _logger
) : IDomainEventHandler<UserCreatedDomainEvent>
{
    public async Task HandleAsync(UserCreatedDomainEvent @event)
    {
        _logger.LogInformation($"Enviando e-mail de confirmação para o UserId:{@event.UserId}");

        var user = await _repo.SingleOrThrow<User>(x => x.Id == @event.UserId);
        string verificationUrl = $"https://seusite.com/verify-email?token={user.EmailVerificationToken}";

        await _emailNotification.SendNotificationAsync(
            user.Email,
            "Verifique seu e-mail",
            "EMAIL",
            $"Clique no link para verificar seu e-mail: {verificationUrl}"
        );

        _logger.LogInformation($"Enviado email de verificação com a VerificationUrl:{verificationUrl}");
    }
}
