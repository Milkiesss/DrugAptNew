using DrugsApt.Domain.ValueObject;
using FluentValidation;

namespace DrugsApt.Domain.Validations.Validators;

public class EmailValidator : AbstractValidator<EmailAddress>
{
     public EmailValidator()
     {
          RuleFor(e => e.Email)
               .MaximumLength(255).WithMessage(ValidationMassage.MaximumNumber)
               .Must(e => e.Contains("@")).WithMessage(ValidationMassage.WrongEmailSyntax);
     }
}