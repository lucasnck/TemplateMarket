using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.Auth.Events;

public class SendConfirmationTokenDomainEventHandler(
    IRepository _repo,
    IEmailNotification _emailNotification
) : INotificationHandler<UserCreatedDomainEvent>
{
    public async Task Handle(UserCreatedDomainEvent notification, CancellationToken ct)
    {
        var user = await _repo.SingleOrThrow<User>(x => x.Id == notification.User.Id);
        string verificationUrl = $"https://seusite.com/verify-email?token={user.EmailVerificationToken}";

        await _emailNotification.SendNotificationAsync(
            user.Email,
            "Verifique seu e-mail",
            "EMAIL",
            $"Clique no link para verificar seu e-mail: {verificationUrl}"
        );
    }
}

