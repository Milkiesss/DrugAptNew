using DrugsApt.Tests.Generators;
using DrugsApt.Domain.Entities;
using DrugsApt.Domain.ValueObject;
using FluentAssertions;
using FluentValidation;
using Xunit;

namespace DrugsApt.Tests.AddressTests;

public class AddressNegativeTest
{
    public static IEnumerable<object[]> TestAddressValidation = NegativeTestDataGenerator.GetAddressValidationExceptionsProperties();
    
    [Theory]
    [MemberData(nameof(TestAddressValidation))]
    public void Add_Address_ThrowValidationException(string city, string street,int house,int postalCode)
    {
        var action = () => new Address(street,city,house,postalCode);
        
        action.Should().Throw<ValidationException>();
    }
    
}