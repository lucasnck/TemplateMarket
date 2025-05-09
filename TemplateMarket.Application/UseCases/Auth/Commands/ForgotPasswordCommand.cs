using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Domain.Events;

namespace TemplateMarket.Application.UseCases.Auth.Commands.ForgotPassword;

public record ForgotPasswordCommand(string Email) : IRequest<Unit>;

public class ForgotPasswordCommandHandler(
    IRepository _repo
) : IRequestHandler<ForgotPasswordCommand, Unit>
{
    public async Task<Unit> Handle(ForgotPasswordCommand request, CancellationToken ct)
    {
        var user = _repo.Query<User>().FirstOrDefault(u => u.Email == request.Email);
        if (user is not null)
        {
            var resetToken = Guid.NewGuid().ToString();
            var resetTokenExpiresAt = DateTime.UtcNow.AddHours(1);

            user.ResetToken = resetToken;
            user.ResetTokenExpiresAt = resetTokenExpiresAt;

            await _repo.SaveChangesAsync();

            user.AddDomainEvent(new UserResetTokenDomainEvent(user.Id));
        }

        return Unit.Value;
    }
}