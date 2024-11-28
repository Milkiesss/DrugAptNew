using DrugsApt.Domain.Entities;
using FluentValidation;

namespace DrugsApt.Domain.Validations.Validators;

public class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .Length(2, 150).WithMessage(ValidationMassage.ErrorLenght)
            .Matches(RegexPattern.NoSpecialCharactersPattern).WithMessage(ValidationMassage.NoSpecialCharacters);
        
        RuleFor(d =>d.Manufacturer)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMassage.ErrorLenght)
            .Matches(RegexPattern.OnlyLettersSpacesAndHyphensPattern).WithMessage(ValidationMassage.OnlyLettersSpacesAndHyphens);

        RuleFor(d => d.CountryCodeId)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty)
            .Matches(RegexPattern.OnlyCapitalLatinLettersPattern).WithMessage(ValidationMassage.OnlyCapitalLatinLetters)
            .Must(countryCodeId => ValidCodeDirectory(countryCodeId)).WithMessage("Invalid code");

        RuleFor(d => d.Country)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
    }
    private bool ValidCodeDirectory(string codeDirectory)
    {
        return codeDirectory.Contains(codeDirectory);
    }
}