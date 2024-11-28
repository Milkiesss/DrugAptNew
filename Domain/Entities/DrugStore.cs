using DrugsApt.Domain.Validations;
using DrugsApt.Domain.Validations.Validators;
using DrugsApt.Domain.ValueObject;
using FluentValidation;

namespace DrugsApt.Domain.Entities;

/// <summary>
/// сущность аптеки
/// </summary>
public class DrugStore : BaseEntity
{
    public string DrugNetwork { get; private set; }
    /// <summary>
    /// Номер аптеки
    /// </summary>
    public int Number { get; private set; }
    /// <summary>
    /// Адрес
    /// </summary>
    public Address Address { get; private set; }
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; private set; }

    /// <summary>
    /// Навигационное поле для связи в DrugItem
    /// </summary>
    public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
    
    public DrugStore(string drugNetwork,int number, Address address, string phoneNumber)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Address = address;
        PhoneNumber = phoneNumber;
        Validate();
    }
    public DrugStore(){}
    public void Validate()
    {
        var validator = new DrugStoreValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(' ', result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}