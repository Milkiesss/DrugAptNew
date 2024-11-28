using DrugsApt.Domain.Validations;
using DrugsApt.Domain.Validations.Validators;
using FluentValidation;

namespace DrugsApt.Domain.ValueObject;

public class EmailAddress
{
    public string Email { get; set; }

    public EmailAddress( string email )
    {
        Email = email;
        Validate();
    }

    public void Validate()
    {
        var validator = new EmailValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(' ', result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
    
    
}