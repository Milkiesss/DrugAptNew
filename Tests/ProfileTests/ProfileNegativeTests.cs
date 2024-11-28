using DrugsApt.Domain.Entities;
using DrugsApt.Domain.ValueObject;
using DrugsApt.Tests.Generators;
using FluentAssertions;
using FluentValidation;
using Xunit;

namespace DrugsApt.Tests.ProfileTests;

public class ProfileNegativeTests
{
    public static IEnumerable<object[]> TestProfileValidator = NegativeTestDataGenerator.GetProfileValidationExceptionsProperties();

    [Theory]
    [MemberData(nameof(TestProfileValidator))]
    public void Add_Profile_ThrowValidationException(string exteranlId, EmailAddress email)
    {
        var action = () => new Profile(exteranlId, email);

        action.Should().Throw<ValidationException>();
    }
}
