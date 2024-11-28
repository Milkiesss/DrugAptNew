using DrugsApt.Domain.Entities;
using FluentValidation;

namespace DrugsApt.Domain.Validations.Validators;

public class ProfileValidator : AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        RuleFor(p => p.ExteranlId)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .Length(6, 7).WithMessage(ValidationMassage.ErrorLenght);

        RuleFor(p => p.Email)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
    }
}