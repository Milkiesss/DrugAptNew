using DrugsApt.Domain.Validations.Validators;
using FluentValidation;

namespace DrugsApt.Domain.Entities;

/// <summary>
/// Лекарство
/// </summary>
public class Drug : BaseEntity
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Производитель
    /// </summary>
    public string Manufacturer { get; set; }
    /// <summary>
    /// Код страны
    /// </summary>
    public string CountryCodeId { get; set; }
    /// <summary>
    /// Страна
    /// </summary>
    public Country Country { get; set; }

    /// <summary>
    /// навигационное поле для связи с DrugItem
    /// </summary>
    public ICollection<DrugItem> DrugItems { get; set; } = new List<DrugItem>();
    
    public Drug(string name, string manufacturer,string countryCodeId, Country country)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = countryCodeId;
        Country = country;
        
        Validate();
    }

    public Drug(){}
    public void Validate()
    {
        var validator = new DrugValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(' ', result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}