using DrugsApt.Domain.Entities;
using DrugsApt.Tests.Generators;
using FluentAssertions;
using FluentValidation;
using Xunit;

namespace DrugsApt.Tests.DrugsTests;

public class DrugNegativeTest
{
    public static IEnumerable<object[]> TestDrugValidator = NegativeTestDataGenerator.GetDrugsValidationExceptionsProperties();

    [Theory]
    [MemberData(nameof(TestDrugValidator))]
    public void Add_Drug_ThrowValidationException(string name, string manufacturer, string countryCodeId, Country country)
    {
        var action = () => new Drug(name, manufacturer, countryCodeId, country);

        action.Should().Throw<ValidationException>();
    }
}