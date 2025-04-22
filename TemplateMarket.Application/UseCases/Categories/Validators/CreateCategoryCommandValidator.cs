using FluentValidation;
using TemplateMarket.Application.UseCases.Templates.Commands;

namespace TemplateMarket.Application.UseCases.Templates.Validators;

public class CreateCategoryCommandValidator : AbstractValidator<CreateTemplateCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required");
    }
}
