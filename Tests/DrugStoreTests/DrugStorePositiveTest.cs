using Bogus;
using Bogus.DataSets;
using DrugsApt.Domain.Entities;
using FluentAssertions;
using Xunit;
using Address = DrugsApt.Domain.ValueObject.Address;

namespace DrugsApt.Tests.DrugStoreTests;

public class DrugStorePositiveTest
{
    private readonly Faker _faker = new();

    [Fact]
    public void Add_Return_DrugStore()
    {
        var drugNetwork = _faker.Random.String2(1,10000);
        var number = _faker.Random.Int(1,100);
        var address =  new Address(_faker.Address.City(), _faker.Address.StreetName(), _faker.Random.Int(1, 100), _faker.Random.Int(10000, 999999));
        var phoneNumber = _faker.Phone.PhoneNumber();
        
        var drugStore = new DrugStore(drugNetwork, number, address, phoneNumber);
        
        drugStore.DrugNetwork.Should().Be(drugNetwork);
        drugStore.Number.Should().Be(number);
        drugStore.Address.Should().Be(address);
        drugStore.PhoneNumber.Should().Be(phoneNumber);
    }
}