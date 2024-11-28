using Bogus;
using DrugsApt.Domain.Entities;
using DrugsApt.Tests.Generators;
using FluentAssertions;
using Xunit;

namespace DrugsApt.Tests.DrugItemTests;

public class DrugItemPositiveTest
{
    private readonly Faker _faker = new();

    [Fact]
    public void Add_Return_DrugItem()
    {
        var drug = DrugGenerator.Generator();
        var drugStore = DrugStoreGenerator.Generator();
        var drugId = drug.Id;
        var drugStoreId = drugStore.Id;
        var price = Math.Round(_faker.Random.Decimal(1, 10), 2);
        var amount = _faker.Random.Int(1,100);
        
        var drugItem = new DrugItem(drugId,drug,drugStoreId,drugStore,price,amount);

        drugItem.DrugId.Should().Be(drugId);
        drugItem.Drug.Should().Be(drug);
        drugItem.DrugStoreId.Should().Be(drugStoreId);
        drugItem.DrugStore.Should().Be(drugStore);
        drugItem.Price.Should().Be(price);
        drugItem.Amount.Should().Be(amount);
    }
}