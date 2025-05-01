using FluentValidation;
using TemplateMarket.Application.UseCases.Products.Commands;

namespace TemplateMarket.Application.UseCases.Products.Validators;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");
    }
}
