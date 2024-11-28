using Bogus;
using DrugsApt.Domain.Entities;
using DrugsApt.Domain.ValueObject;

namespace DrugsApt.Tests.Generators;

public class ProfileGenerator
{
    private static readonly Faker<Profile> _profileFaker = new Faker<Profile>()
        .CustomInstantiator(p =>
        {
            return new Profile(
                p.Random.AlphaNumeric(7), 
                new EmailAddress(p.Internet.Email())
            );
        });
    
    public static Profile Generate()
    {
        return _profileFaker.Generate();
    }
}