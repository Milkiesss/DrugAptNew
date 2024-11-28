using DrugsApt.Domain.Entities;
using DrugsApt.Tests.Generators;
using FluentAssertions;
using FluentValidation;
using Xunit;

namespace DrugsApt.Tests.CountryTests;

public class CountryNegativeTest
{
    public static IEnumerable<object[]> TestCountryValidation = NegativeTestDataGenerator.GetCountryValidationExceptionsProperties();

    [Theory]
    [MemberData(nameof(TestCountryValidation))]
    public void Add_Country_ThrowValidationException(string name, string code)
    {
        var action = () => new Country(name, code);

        action.Should().Throw<ValidationException>();
    }
}