using Bogus;
using DrugsApt.Domain.DomainEvents;
using DrugsApt.Domain.Entities;
using DrugsApt.Tests.Generators;
using FluentAssertions;
using Xunit;

namespace DrugsApt.Tests.DrugItemUpdatedEventTests;

public class DrugItemUpdatedEventPositiveTests
{
    private readonly Faker _faker = new();

    [Fact]
    public void Add_Return_DrugItemUpdatedEvent()
    {
        var drugitem = DrugItemGenerator.Generator();
        
        var drugId = drugitem.DrugId;
        var drugStoreId = drugitem.DrugStoreId;
        var amount = _faker.Random.Double(1, 100);
        
        var drugStore = new DrugItemUpdatedEvent(drugId, drugStoreId, amount);
        
        drugStore.DrugId.Should().Be(drugId);
        drugStore.DrugStoreId.Should().Be(drugStoreId);
        drugStore.Amount.Should().Be(amount);
        
        drugitem.UpdateDrugAmount(10);
        drugitem.GetDomainEvents().Count.Should().Be(1);
        
        drugitem.ClearDomainEvents();
        drugitem.GetDomainEvents().Should().BeEmpty();
    }
}