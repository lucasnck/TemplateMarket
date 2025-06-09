using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Application.Common.Validators;
using TemplateMarket.Application.UseCases.UserCompanies.Commands;
using TemplateMarket.Domain.Common.Errors;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Application.UseCases.Auth.Validators;

public class CreateUserCompanyOwnerCommandValidator : AbstractValidator<CreateUserCompanyOwnerCommand>
{
    IRepository _repo;

    public CreateUserCompanyOwnerCommandValidator(
        IRepository repo
    )
    {
        _repo = repo;

        RuleFor(x => x.Identification)
            .NotEmpty()
            .WithMessage(Errors.Entity.IDENTIFICATION_REQUIRED)
            .Must(CnpjValidator.IsValid)
            .WithMessage(Errors.Entity.IDENTIFICATION_INVALID)
            .MustAsync(AlreadyExistsIdentification)
            .WithMessage(Errors.Entity.IDENTIFICATION_NOT_AVAILABLE);

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(Errors.Entity.NAME_REQUIRED);

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(Errors.Company.EMAIL_REQUIRED)
            .EmailAddress()
            .WithMessage(Errors.Company.EMAIL_INVALID)
            .MustAsync(AlreadyExistsEmail)
            .WithMessage(Errors.Company.EMAIL_NOT_AVAILABLE);

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage(Errors.Company.PHONE_REQUIRED)
            .Must(PhoneValidator.IsValid)
            .WithMessage(Errors.Company.PHONE_INVALID)
            .MustAsync(AlreadyExistsPhone)
            .WithMessage(Errors.Company.PHONE_NOT_AVAILABLE);
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
