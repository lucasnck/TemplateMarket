using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;

public record VerifyEmailCommand(string Token) : IRequest;

public class VerifyEmailCommandHandler(
    IRepository _repo
) : IRequestHandler<VerifyEmailCommand>
{
    public async Task<Unit> Handle(VerifyEmailCommand request, CancellationToken ct)
    {
        var user = _repo.Query<User>()
            .FirstOrDefault(u => u.EmailVerificationToken == request.Token); 
        
        user.IsEmailVerified = true;
        user.EmailVerificationToken = null;
        user.EmailVerificationTokenExpiresAt = null;

        await _repo.SaveChangesAsync();
        return Unit.Value;
    }
}
