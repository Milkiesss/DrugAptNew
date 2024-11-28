using DrugsApt.Domain.Entities;
using FluentValidation;

namespace DrugsApt.Domain.Validations.Validators;

public class DrugItemValidator : AbstractValidator<DrugItem>
{
    public DrugItemValidator()
    {
        RuleFor(di => di.Price)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .GreaterThan(0).WithMessage(ValidationMassage.PositiveNumber)
            .PrecisionScale(10,2, true).WithMessage(ValidationMassage.DecimalNumber);

        RuleFor(di => di.Amount)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMassage.PositiveNumber)
            .LessThanOrEqualTo(10000).WithMessage(ValidationMassage.MaximumNumber);

        RuleFor(di => di.DrugId)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
        
        RuleFor(di => di.Drug)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
        
        RuleFor(di => di.DrugStoreId)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
        
        RuleFor(di => di.DrugStore)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
    }
}