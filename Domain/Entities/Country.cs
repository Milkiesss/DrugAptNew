using DrugsApt.Domain.Validations;
using DrugsApt.Domain.Validations.Validators;
using FluentValidation;
using MediatR;

namespace DrugsApt.Domain.Entities;

public class Country : BaseEntity
{
    /// <summary>
    /// Страна
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Код страны
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Навигационное поле для связи с Drug 
    /// </summary>
    public ICollection<Drug> Drugs { get; set; } = new List<Drug>();
    
    public Country(string name, string code)
    {
        Name = name;
        Code = code;
        Validate();
    }
    public Country(){}

    public void Validate()
    {
        var validator = new CountryValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(' ', result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
    
}