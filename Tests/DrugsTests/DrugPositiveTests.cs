using Bogus;
using DrugsApt.Domain.Entities;
using DrugsApt.Tests.Generators;
using FluentAssertions;
using Xunit;

namespace DrugsApt.Tests.DrugsTests;

public class DrugPositiveTests
{
   private readonly Faker _faker = new();

   [Fact]
   public void Add_Return_Drug()
   {
      var name = _faker.Random.String2(2,150);
      var manufacturer = _faker.Random.String2(2,100);
      var country = CoutryGenerator.Generator();
      var coutryCodeId = country.Code;
      
      var drug = new Drug(name, manufacturer, coutryCodeId, country);
      
      drug.Name.Should().Be(name);
      drug.Manufacturer.Should().Be(manufacturer);
      drug.CountryCodeId.Should().Be(coutryCodeId);
      drug.Country.Should().Be(country);
      
   }
}