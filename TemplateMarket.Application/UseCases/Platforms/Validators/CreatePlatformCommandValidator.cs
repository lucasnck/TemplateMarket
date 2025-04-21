using FluentValidation;
using TemplateMarket.Application.UseCases.Platforms.Commands;

namespace TemplateMarket.Application.UseCases.Templates.Validators;

public class CreatePlatformCommandValidator : AbstractValidator<CreatePlatformCommand>
{
    public CreatePlatformCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required");
    }
}
