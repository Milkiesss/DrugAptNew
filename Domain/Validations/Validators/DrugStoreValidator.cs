using DrugsApt.Domain.Entities;
using FluentValidation;

namespace DrugsApt.Domain.Validations.Validators;

public class DrugStoreValidator : AbstractValidator<DrugStore>
{
    public DrugStoreValidator()
    {
        RuleFor(ds=>ds.DrugNetwork)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .MaximumLength(10000).WithMessage(ValidationMassage.ErrorLenght);

        RuleFor(ds => ds.Number)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .GreaterThan(0).WithMessage(ValidationMassage.PositiveNumber);

        RuleFor(ds => ds.Address)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
        
        RuleFor(ds => ds.PhoneNumber)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
    }
}