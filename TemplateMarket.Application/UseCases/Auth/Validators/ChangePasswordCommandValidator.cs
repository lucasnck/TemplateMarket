using FluentValidation;

namespace TemplateMarket.Application.UseCases.Auth.Commands.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(x => x.CurrentPassword)
            .NotEmpty().WithMessage("A senha atual é obrigatória.");

        RuleFor(x => x.NewPassword)
            .NotEmpty().MinimumLength(6).WithMessage("A nova senha deve ter pelo menos 6 caracteres.");
    }
}
