using Bogus;
using DrugsApt.Domain.Entities;
using DrugsApt.Tests.Generators;
using FluentAssertions;
using Xunit;

namespace DrugsApt.Tests.FavoriteDrugTests;

public class FavoriteDrugPositiveTests
{
    private readonly Faker _faker = new();

    [Fact]
    public void Add_Return_FavoriteDrug()
    {
        var profile = ProfileGenerator.Generate();
        var drug = DrugGenerator.Generator();
        var drugStore = DrugStoreGenerator.Generator();
        var profileId = profile.Id;
        var drugId = drug.Id;
        var drugstoreId = drugStore.Id;
      
        var favoriteDrug = new FavoriteDrug(profileId, profile, drugId, drugstoreId,drug,drugStore);
      
        favoriteDrug.Profile.Should().Be(profile);
        favoriteDrug.Drug.Should().Be(drug);
        favoriteDrug.ProfileId.Should().Be(profileId);
        favoriteDrug.DrugId.Should().Be(drugId);
      
    }
}