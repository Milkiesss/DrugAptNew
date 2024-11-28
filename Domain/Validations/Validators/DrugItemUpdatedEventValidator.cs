using DrugsApt.Domain.DomainEvents;
using FluentValidation;

namespace DrugsApt.Domain.Validations.Validators;

public class DrugItemUpdatedEventValidator : AbstractValidator<DrugItemUpdatedEvent>
{
    public DrugItemUpdatedEventValidator()
    {
        RuleFor(d => d.DrugId)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
        
        RuleFor(d => d.DrugStoreId)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);

        RuleFor(d => d.Amount)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .GreaterThan(0).WithMessage(ValidationMassage.PositiveNumber);
    }
}