using FluentValidation;
using TemplateMarket.Application.UseCases.Templates.Commands;

public class DeletePlatformCommandValidator : AbstractValidator<DeletePlatformCommand>
{
    public DeletePlatformCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");
    }
}

