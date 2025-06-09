using FluentValidation;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Validators;
using TemplateMarket.Domain.Common.Errors;
using TemplateMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TemplateMarket.Application.UseCases.Auth.Validators;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    IRepository _repo;

    public RegisterUserCommandValidator(
        IRepository repo
    )
    {
        _repo = repo;

        RuleFor(x => x.Identification)
            .NotEmpty()
            .WithMessage(Errors.Entity.IDENTIFICATION_REQUIRED)
            .Must(CpfValidator.IsValid)
            .WithMessage(Errors.Entity.IDENTIFICATION_INVALID)
            .MustAsync(AlreadyExistsIdentification)
            .WithMessage(Errors.Entity.IDENTIFICATION_NOT_AVAILABLE);

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(Errors.Entity.NAME_REQUIRED);

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(Errors.User.EMAIL_REQUIRED)
            .EmailAddress()
            .WithMessage(Errors.User.EMAIL_INVALID)
            .MustAsync(AlreadyExistsEmail)
            .WithMessage(Errors.User.EMAIL_NOT_AVAILABLE);

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage(Errors.User.PHONE_REQUIRED)
            .Must(PhoneValidator.IsValid)
            .WithMessage(Errors.User.PHONE_INVALID)
            .MustAsync(AlreadyExistsPhone)
            .WithMessage(Errors.User.PHONE_NOT_AVAILABLE);

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(Errors.User.PASSWORD_REQUIRED)
            .MinimumLength(6)
            .WithMessage(Errors.User.PASSWORD_MIN_LENGHT_6)
            .Must(PasswordValidator.IsValid)
            .WithMessage(Errors.User.PASSWORD_INVALID);
    }

    private async Task<bool> AlreadyExistsIdentification(string value, CancellationToken ct)
        => !await _repo.Query<User>()
                .AnyAsync(u => u.Entity.Identification == value, ct);

    private async Task<bool> AlreadyExistsEmail(string value, CancellationToken ct)
        => !await _repo.Query<User>()
                .AnyAsync(u => u.Email == value, ct);

    private async Task<bool> AlreadyExistsPhone(string value, CancellationToken ct)
        => !await _repo.Query<User>()
                .AnyAsync(u => u.Phone == value, ct);
}
