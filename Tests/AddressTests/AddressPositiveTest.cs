﻿using Bogus;
using DrugsApt.Domain.ValueObject;
using FluentAssertions;
using Xunit;

namespace DrugsApt.Tests.AddressTests;

public class AddressPositiveTest
{
    private readonly Faker _faker = new();
    
    [Fact]
    public void Add_Return_Address()
    {
        var street = _faker.Address.StreetName();
        var city = _faker.Address.City();
        var house = _faker.Random.Int(10, 100);
        var postalCode = _faker.Random.Int(10000, 999999);
        
        var address = new Address(street, city, house, postalCode);
        
        address.Street.Should().Be(street);
        address.City.Should().Be(city);
        address.House.Should().Be(house);
        address.PostalCode.Should().Be(postalCode);
    }
}