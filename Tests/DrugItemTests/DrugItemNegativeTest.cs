using FluentAssertions;
using FluentValidation;
using Xunit;
using DrugsApt.Domain.Entities;
using DrugsApt.Tests.Generators;

namespace DrugsApt.Tests.DrugItemTests;

public class DrugItemNegativeTest
{
    public static IEnumerable<object[]> TestDrugItemValidator = NegativeTestDataGenerator.GetDrugsItemValidationExceptionsProperties();

    [Theory]
    [MemberData(nameof(TestDrugItemValidator))]
    public void Add_DrugItem_ThrowValidationException(Guid drugId, Drug drug, Guid drugStoreId, DrugStore drugStore, decimal price, int amount)
    {
        var action = () => new DrugItem(drugId,drug,drugStoreId,drugStore,price,amount);

        action.Should().Throw<ValidationException>();
    }
    
}