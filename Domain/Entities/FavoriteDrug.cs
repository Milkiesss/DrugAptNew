using DrugsApt.Domain.Validations;
using DrugsApt.Domain.Validations.Validators;
using FluentValidation;

namespace DrugsApt.Domain.Entities;
/// <summary>
/// избранный препарат
/// </summary>
public class FavoriteDrug : BaseEntity
{
    /// <summary>
    /// идентификатор профиля
    /// </summary>
    public Guid ProfileId { get; private set; }
    /// <summary>
    /// идентификатор препарата
    /// </summary>
    public Guid DrugId { get; private set; }
    /// <summary>
    /// идентификатор аптеки
    /// </summary>
    public Guid? DrugStoreId { get; private set; }
    
    //нафигационные свойства
    public Drug Drug {get; private set;}
    public Profile Profile { get; private set; }
    public DrugStore? DrugStore { get; private set; }
    public FavoriteDrug(
        Guid profileId,
        Profile profile,
        Guid drugId,
        Guid drugStoreId,
        Drug drug,
        DrugStore drugStore)
    {
        ProfileId = profileId;
        Profile = profile;
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        Drug = drug;
        DrugStore = drugStore;
        
        Validate();
    }
    public FavoriteDrug(){}

    public void Validate()
    {
        var validator = new FavoriteDrugValidator();
        var result = validator.Validate(this);
        
        if (!result.IsValid)
        {
            var errors = string.Join(' ', result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}