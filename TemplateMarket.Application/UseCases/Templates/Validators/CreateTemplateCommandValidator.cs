using FluentValidation;
using TemplateMarket.Application.UseCases.Templates.Commands;

namespace TemplateMarket.Application.UseCases.Templates.Validators;

public class CreateTemplateCommandValidator : AbstractValidator<CreateTemplateCommand>
{
    public CreateTemplateCommandValidator()
    {
        RuleFor(x => x.CreateTemplateDto.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(100)
            .WithMessage("Name must be at most 100 characters");
    }
}
