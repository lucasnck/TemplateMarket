using FluentValidation;
using TemplateMarket.Application.UseCases.Platforms.Commands;
public class UpdatePlatformCommandValidator : AbstractValidator<UpdatePlatformCommand>
{
    public UpdatePlatformCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
