using FluentValidation;
using MediatR;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Auth.Commands.ForgotPassword;

public class VerifyEmailCommandValidator : AbstractValidator<VerifyEmailCommand>
{
    public IRepository _repo;

    public VerifyEmailCommandValidator(
        IRepository repo
    )
    {
        _repo = repo;

        RuleFor(x => x.Token)
            .NotEmpty()
            .Must(ValidateToken)
            .WithMessage("Token não é válido ou está expirado");
    }

    private bool ValidateToken(string token)
    {
        var user = _repo.Query<User>()
            .FirstOrDefault(u => u.EmailVerificationToken == token);

        return (user != null || user?.EmailVerificationTokenExpiresAt > DateTime.UtcNow);
    }
}
