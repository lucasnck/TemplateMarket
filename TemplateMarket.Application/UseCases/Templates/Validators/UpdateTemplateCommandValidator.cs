using FluentValidation;
using TemplateMarket.Application.UseCases.Templates.Commands;

public class UpdateTemplateCommandValidator : AbstractValidator<UpdateTemplateCommand>
{
    public UpdateTemplateCommandValidator()
    {
        RuleFor(x => x.UpdateTemplateDto.Id)
            .NotEmpty().WithMessage("Id is required");

        RuleFor(x => x.UpdateTemplateDto.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Price must be a positive number");
    }
}
