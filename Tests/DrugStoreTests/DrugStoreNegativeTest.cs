using DrugsApt.Domain.Entities;
using DrugsApt.Tests.Generators;
using FluentAssertions;
using FluentValidation;
using Xunit;
using Address = DrugsApt.Domain.ValueObject.Address;

namespace DrugsApt.Tests.DrugStoreTests;

public class DrugStoreNegativeTest
{
    public static IEnumerable<object[]> TestDrugStoreValidator = NegativeTestDataGenerator.GetDrugStoreValidationExceptionsProperties();

    [Theory]
    [MemberData(nameof(TestDrugStoreValidator))]
    public void Add_DrugItem_ThrowValidationException(string drugNetwork,int number, Address address, string phoneNumber)
    {
        var action = () => new DrugStore(drugNetwork,number,address,phoneNumber);

        action.Should().Throw<ValidationException>();
    }
}