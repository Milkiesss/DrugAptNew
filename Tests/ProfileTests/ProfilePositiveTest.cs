using Bogus;
using DrugsApt.Domain.Entities;
using DrugsApt.Domain.ValueObject;
using DrugsApt.Tests.Generators;
using FluentAssertions;
using Xunit;

namespace DrugsApt.Tests.ProfileTests;

public class ProfilePositiveTest
{
    private readonly Faker _faker = new();

    [Fact]
    public void Add_Return_Drug()
    {
        var exteranlId = _faker.Random.AlphaNumeric(7).ToString();
        var email = new EmailAddress(_faker.Internet.Email());
      
        var profile = new Profile(exteranlId, email);
      
        profile.ExteranlId.Should().Be(exteranlId);
        profile.Email.Should().Be(email);
    }
}