using FluentValidation;
using TemplateMarket.Application.UseCases.Products.Commands;

namespace TemplateMarket.Application.UseCases.Templates.Validators;

public class CreateCategoryCommandValidator : AbstractValidator<CreateProductCommand>
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
