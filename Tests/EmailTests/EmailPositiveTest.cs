using Bogus;
using DrugsApt.Domain.Entities;
using DrugsApt.Domain.ValueObject;
using DrugsApt.Tests.Generators;
using FluentAssertions;
using Xunit;

namespace DrugsApt.Tests.EmailTests;

public class EmailPositiveTest
{
    private readonly Faker _faker = new();

    [Fact]
    public void Add_Return_EmailAddress()
    {
        var email = _faker.Internet.Email();

      
        var emailAddress = new EmailAddress(email);
      
        emailAddress.Email.Should().Be(email);
    }
}