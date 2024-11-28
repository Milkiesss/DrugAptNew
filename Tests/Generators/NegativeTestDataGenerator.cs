using Bogus;
using DrugsApt.Domain.Entities;
using DrugsApt.Domain.Validations.Validators;
using DrugsApt.Domain.ValueObject;

namespace DrugsApt.Tests.Generators;

public class NegativeTestDataGenerator
{
    private static readonly Faker _faker = new();

    /// <summary>
    /// генерация данных для ValidationException сущность Address
    /// </summary>
    /// <returns>набор тестовых данных</returns>
    public static IEnumerable<object[]> GetAddressValidationExceptionsProperties()
    {
        return new List<object[]>
        {
            new object[] {null,_faker.Address.StreetName(),_faker.Random.Int(1,10),_faker.Random.Int(10000,999999)},
            new object[] {_faker.Address.City(),null,_faker.Random.Int(1,10),_faker.Random.Int(10000,999999)},
            new object[] {_faker.Address.City(),_faker.Address.StreetName(),null,_faker.Random.Int(10000,999999)},
            new object[] {_faker.Address.City(),_faker.Address.StreetName(),_faker.Random.Int(1,10),_faker.Random.Int(0,100)}
        };
    }

    /// <summary>
    /// генерация данных для ValidationException сущность Country
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<object[]> GetCountryValidationExceptionsProperties()
    {
        return new List<object[]>
        {
            new object[] { null, _faker.PickRandom(CountryValidator.CodeDirectory).ToString()},
            new object[] { _faker.Address.Country(), null }
        };
    }
    
    /// <summary>
    /// генерация данных для ValidationException сущность Drug
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<object[]> GetDrugsValidationExceptionsProperties()
    {
        var country = CoutryGenerator.Generator();
        return new List<object[]>
        {
            new object[] { null, _faker.Random.String2(2,50),country.Code,country},
            new object[] { _faker.Random.String2(2,150), null,country.Code,country },
            new object[] { _faker.Random.String2(2,28), _faker.Random.String2(2,50),null,country },
            new object[] { _faker.Random.String2(2,28), _faker.Random.String2(2,50),country.Code,null }
        };
    }
    
    /// <summary>
    /// генерация данных для ValidationException сущность DrugItem
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<object[]> GetDrugsItemValidationExceptionsProperties()
    {
        var drugStore = DrugStoreGenerator.Generator();
        var drug = DrugGenerator.Generator();
        return new List<object[]>
        {
            new object[] {null, drug, drugStore.Id, drugStore, _faker.Random.Decimal(1), _faker.Random.Int(1, 1000) },
            new object[] {drug.Id, null, drugStore.Id, drugStore, _faker.Random.Decimal(1), _faker.Random.Int(1, 1000) },
            new object[] {drug.Id, drug, null, drugStore, _faker.Random.Decimal(1), _faker.Random.Int(1, 1000) },
            new object[] {drug.Id, drug, drugStore.Id, null, _faker.Random.Decimal(1), _faker.Random.Int(1, 1000) },
            new object[] {drug.Id, drug, drugStore.Id, drugStore, -1, _faker.Random.Int(1, 1000) },
            new object[] {drug.Id, drug, drugStore.Id, drugStore, _faker.Random.Decimal(1), -1 } 
        };
    }
    
    /// <summary>
    /// генерация данных для ValidationException сущность DrugStore
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<object[]> GetDrugStoreValidationExceptionsProperties()
    {
        var country = CoutryGenerator.Generator();
        return new List<object[]>
        {
            new object[] { null, _faker.Random.Int(1,10), new Address(_faker.Address.StreetName(), _faker.Address.City(),_faker.Random.Int(1,10),_faker.Random.Int(10000,999999)), _faker.Phone.PhoneNumber()},
            new object[] { _faker.Random.String2(1,10000),null, new Address(_faker.Address.StreetName(), _faker.Address.City(),_faker.Random.Int(1,10),_faker.Random.Int(10000,999999)), _faker.Phone.PhoneNumber()},
            new object[] { _faker.Random.String2(1,10000), _faker.Random.Int(1,10), null, _faker.Phone.PhoneNumber()},
            new object[] { _faker.Random.String2(1,10000), _faker.Random.Int(1,10), new Address(_faker.Address.StreetName(), _faker.Address.City(),_faker.Random.Int(1,10),_faker.Random.Int(10000,999999)), null},
        };
    }
    
    /// <summary>
    /// генерация данных для ValidationException сущность Email
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<object[]> GetEmailAddressValidationExceptionsProperties()
    {
        var country = CoutryGenerator.Generator();
        return new List<object[]>
        {
            new object[] {_faker.Random.Int(20)},
        };
    }
    
    /// <summary>
    /// генерация данных для ValidationException сущность Profile
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<object[]> GetProfileValidationExceptionsProperties()
    {
        var country = CoutryGenerator.Generator();
        return new List<object[]>
        {
            new object[] { null, new EmailAddress(_faker.Internet.Email())},
            new object[] {_faker.Random.AlphaNumeric(7),null},
        };
    }
    
    
    /// <summary>
    /// генерация данных для ValidationException сущность FavoriteDrug
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<object[]> GetFavoriteDrugValidationExceptionsProperties()
    {
        var profile = ProfileGenerator.Generate();
        var drug = DrugGenerator.Generator();
        var drugStore = DrugStoreGenerator.Generator();
        return new List<object[]>
        {
            new object[] {null, profile, drug.Id, drug},
            new object[] {profile.Id, null, drug.Id,drug},
            new object[] {profile.Id, profile, null,drug},
            new object[] {profile.Id, profile, drug.Id,null},
        };
    }
    
    /// <summary>
    /// генерация данных для ValidationException сущность DrugItemUpdatedEvent
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<object[]> GetDrugItemUpdatedEventValidationExceptionsProperties()
    {
        var drugitem = DrugItemGenerator.Generator();
        return new List<object[]>
        {
            new object[] {null, drugitem.DrugStoreId, 10},
            new object[] {drugitem.DrugId, null, 10},
            new object[] {drugitem.DrugId,drugitem.DrugStoreId, -1},
        };
    }
}