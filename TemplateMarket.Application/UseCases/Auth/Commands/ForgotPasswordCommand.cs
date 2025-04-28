using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Auth.Commands.ForgotPassword;

public record ForgotPasswordCommand(string Email) : IRequest<Unit>;

public class ForgotPasswordCommandHandler(
    IRepository<User> _repository
) : IRequestHandler<ForgotPasswordCommand, Unit>
{
    public async Task<Unit> Handle(ForgotPasswordCommand request, CancellationToken ct)
    {
        var user = await _repository.SingleOrDefaultAsync(u => u.Email == request.Email);
        if (user is not null)
        {
            var resetToken = Guid.NewGuid().ToString();
            var resetTokenExpiresAt = DateTime.UtcNow.AddHours(1);

            user.ResetToken = resetToken;
            user.ResetTokenExpiresAt = resetTokenExpiresAt;

            await _repository.SaveChangesAsync();
            // simulação de envio de e-mail
            Console.WriteLine($"Token para {user.Email}: {user.ResetToken}");
        }

        return Unit.Value;
    }
}