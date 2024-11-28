using DrugsApt.Domain.Entities;
using FluentValidation;

namespace DrugsApt.Domain.Validations.Validators;

public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(c => c.Name)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .Matches(RegexPattern.OnlyLettersAndSpacesPattern).WithMessage(ValidationMassage.OnlyLettersAndSpaces)
            .Length(2, 100).WithMessage(ValidationMassage.ErrorLenght);
        
        RuleFor(c => c.Code)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .Matches(RegexPattern.OnlyCapitalLatinLettersPattern).WithMessage(ValidationMassage.OnlyCapitalLatinLetters)
            .Must(code => CodeDirectory().Contains(code)).WithMessage("Invalid country code");
    }
    
    public static List<string> CodeDirectory() =>
        new()
        {
            "AL", "AM", "AT", "AZ", "BA", "BE", "BG", "BY", "CH", "CY", "CZ", "DE", "DK", 
            "EE", "ES", "FI", "FO", "FR", "GE", "GR", "HR", "HU", "IE", "IL", "IT", "KZ", 
            "KW", "LV", "LI", "LT", "LU", "MK", "MD", "ME", "NL", "NO", "PL", "PT", "RO", 
            "RU", "SE", "SI", "SK", "SM", "UA", "GB", "VA", "US"
        };
}