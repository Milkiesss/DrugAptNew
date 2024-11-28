using DrugsApt.Domain.Validations;
using DrugsApt.Domain.Validations.Validators;
using DrugsApt.Domain.ValueObject;
using FluentValidation;

namespace DrugsApt.Domain.Entities;
/// <summary>
/// сущности пользователя
/// </summary>
public class Profile : BaseEntity
{
    /// <summary>
    /// внешний идентификатор
    /// </summary>
    public string ExteranlId { get; set; }
    /// <summary>
    /// Email Адрес
    /// </summary>
    public EmailAddress Email { get; set; }
    
    /// <summary>
    /// навигационное свойство
    /// </summary>
    public List<FavoriteDrug> FavoriteDrugs { get; set; }
    
    public Profile(string externalId, EmailAddress email)
    {
        ExteranlId = externalId;
        Email = email;
        Validate();
    }
    public Profile(){}
    
    public void Validate()
    {
        var validator = new ProfileValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(' ', result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}