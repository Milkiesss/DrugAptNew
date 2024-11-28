using DrugsApt.Domain.Validations;
using DrugsApt.Domain.Validations.Validators;
using FluentValidation;

namespace DrugsApt.Domain.ValueObject;

public class Address : BaseValueObject
{
    public Address(string street, string city, int house, int postalCode)
    {
        Street = street;
        City = city;
        House = house;
        PostalCode = postalCode;
        
        Validate();
    }
    
    public void Validate()
    {
        var validator = new AddressValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(' ', result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
    /// <summary>
    /// Улица
    /// </summary>
    public string Street { get; private set; }
    /// <summary>
    /// Город
    /// </summary>
    public string City { get; private set; }
    /// <summary>
    /// Дом
    /// </summary>
    public int House { get; private set; }
    /// <summary>
    /// почтовый индекс
    /// </summary>
    public int PostalCode { get; private set; }
        
}