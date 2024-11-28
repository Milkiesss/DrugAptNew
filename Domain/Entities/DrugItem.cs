using DrugsApt.Domain.DomainEvents;
using DrugsApt.Domain.Validations;
using DrugsApt.Domain.Validations.Validators;
using FluentValidation;

namespace DrugsApt.Domain.Entities;
/// <summary>
/// связь между DrugStore и Drug
/// </summary>
public class DrugItem : BaseEntity
{
    public DrugItem( Guid drugId, Drug drug, Guid drugStoreId, DrugStore drugStore, decimal price, double amount)
    {
        DrugId = drugId;
        Drug = drug;
        DrugStoreId = drugStoreId;
        DrugStore = drugStore;
        Price = price;
        Amount = amount;

        Validate();
    }

    public DrugItem(){}
    public void UpdateDrugAmount(double amount)
    {
        Amount += amount;
        Validate();
        
        AddDomainEvent(new DrugItemUpdatedEvent(this.Id,this.DrugStoreId, Amount));
    }
    
    public void Validate()
    {
        var validator = new DrugItemValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(' ', result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
    /// <summary>
    /// Id лекарства
    /// </summary>
    public Guid DrugId { get; set; }
    /// <summary>
    /// Id Аптеки
    /// </summary>
    public Guid DrugStoreId { get; set; }
    /// <summary>
    /// Лекарство
    /// </summary>
    public Drug Drug { get; set; }
    /// <summary>
    /// Аптека
    /// </summary>
    public DrugStore DrugStore { get; set; }
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }
    /// <summary>
    /// Кол-во
    /// </summary>
    public double Amount { get; set; }
}