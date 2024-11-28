using DrugsApt.Domain.DomainEvents;
using DrugsApt.Tests.Generators;
using FluentAssertions;
using FluentValidation;
using Xunit;

namespace DrugsApt.Tests.DrugItemUpdatedEventTests;

public class DrugItemUpdatedEventNegativeTests
{
    public static IEnumerable<object[]> TestDrugItemUpdatedEventValidator = NegativeTestDataGenerator.GetDrugItemUpdatedEventValidationExceptionsProperties();

    [Theory]
    [MemberData(nameof(TestDrugItemUpdatedEventValidator))]
    public void Add_DrugItem_ThrowValidationException(Guid drugId,Guid drugStoreId, double amount)
    {
        var action = () => new DrugItemUpdatedEvent(drugId,drugStoreId,amount);

        action.Should().Throw<ValidationException>();
    }
}