using Bogus;
using DrugsApt.Domain.Entities;
using DrugsApt.Domain.Validations.Validators;

namespace DrugsApt.Tests.Generators;

/// <summary>
/// Генератор сущности Country для тестов
/// </summary>
public class CoutryGenerator
{
    private static readonly Faker<Country> _fakerCountry = new Faker<Domain.Entities.Country>()
        .CustomInstantiator(c => new Country(
            c.Random.String2(10),
            c.PickRandom(CountryValidator.CodeDirectory).ToString()
        ));

    public static Domain.Entities.Country Generator()
    {
        return _fakerCountry.Generate();
    }
}