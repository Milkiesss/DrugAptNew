using DrugsApt.Domain.ValueObject;
using FluentValidation;

namespace DrugsApt.Domain.Validations.Validators;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(a => a.Street)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .Length(3, 100).WithMessage(ValidationMassage.ErrorLenght);
        
        RuleFor(a=>a.City)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .Length(5, 50).WithMessage(ValidationMassage.ErrorLenght);
        
        RuleFor(a=>a.House)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .GreaterThan(0).WithMessage(ValidationMassage.MinimumNumber);

        RuleFor(a => a.PostalCode)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .GreaterThanOrEqualTo(10000).WithMessage(ValidationMassage.MinimumNumber)
            .LessThanOrEqualTo(999999).WithMessage(ValidationMassage.MaximumNumber);
        
    }
}