using MediatR;
using TemplateMarket.Application.Common.Extensions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.Auth.Events;

public class SendResetPaswwordTokenDomainEventHandler(
    IRepository _repo,
    IEmailNotification _emailNotification
) : INotificationHandler<UserResetTokenDomainEvent>
{
    public async Task Handle(UserResetTokenDomainEvent notification, CancellationToken ct)
    {
        var user = await _repo.SingleOrThrow<User>(x => x.Id == notification.Id);
        string verificationUrl = $"https://seusite.com/verify-email?token={user.ResetToken}";

        await _emailNotification.SendNotificationAsync(
            user.Email,
            "Verifique seu e-mail",
            "EMAIL",
            $"Clique no link para verificar seu e-mail: {verificationUrl}"
        );
    }
}
