using DrugsApt.Domain.Interface;
using DrugsApt.Domain.Validations.Validators;
using FluentValidation;


namespace DrugsApt.Domain.DomainEvents;

public class DrugItemUpdatedEvent : IDomainEvent
{
    public Guid DrugId { get; private set; }
    public Guid DrugStoreId {get; private set;}
    public double Amount { get; private set; }
    public DrugItemUpdatedEvent(Guid drugId,Guid drugStoreId, double amount)
    {
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        Amount = amount;
        
        Validate();
    }
    public void Validate()
    {
        var validator = new DrugItemUpdatedEventValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(' ', result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
    
}