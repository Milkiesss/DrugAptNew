using Bogus;
using DrugsApt.Domain.Entities;
using DrugsApt.Domain.Validations.Validators;
using FluentAssertions;
using Xunit;

namespace DrugsApt.Tests.CountryTests;

public class CountryPositiveTest
{
    private readonly Faker _faker = new();

    [Fact]
    public void Add_Return_Country()
    {
        var name = _faker.Address.Country();
        var code = _faker.PickRandom(CountryValidator.CodeDirectory).ToString();

        var country = new Country(name, code);

        country.Name.Should().Be(name);
        country.Code.Should().Be(code);
    }
}