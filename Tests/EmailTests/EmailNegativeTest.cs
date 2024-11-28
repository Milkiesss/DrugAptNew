using DrugsApt.Domain.Entities;
using DrugsApt.Domain.ValueObject;
using DrugsApt.Tests.Generators;
using FluentAssertions;
using FluentValidation;
using Xunit;

namespace DrugsApt.Tests.EmailTests;

public class EmailNegativeTest
{
    public static IEnumerable<object[]> TestEmailAddressValidator = NegativeTestDataGenerator.GetEmailAddressValidationExceptionsProperties();

    [Theory]
    [MemberData(nameof(TestEmailAddressValidator))]
    public void Add_EmailAddress_ThrowValidationException(string email)
    {
        var action = () => new EmailAddress(email);

        action.Should().Throw<ValidationException>();
    }
}