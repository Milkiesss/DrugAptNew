using DrugsApt.Domain.Entities;
using FluentValidation;

namespace DrugsApt.Domain.Validations.Validators;

public class FavoriteDrugValidator : AbstractValidator<FavoriteDrug>
{
    public FavoriteDrugValidator()
    {
        RuleFor(fd => fd.ProfileId)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
        RuleFor(fd => fd.Profile)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
        
        RuleFor(fd => fd.DrugId)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
        RuleFor(fd => fd.Drug)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
        
        RuleFor(fd => fd.DrugStoreId)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
        RuleFor(fd => fd.DrugStore)
            .NotNull().WithMessage(ValidationMassage.NotNull)
            .NotEmpty().WithMessage(ValidationMassage.NotEmpty);
    }
}