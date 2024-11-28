using DrugsApt.Domain.Entities;
using DrugsApt.Tests.Generators;
using FluentAssertions;
using FluentValidation;
using Xunit;

namespace DrugsApt.Tests.FavoriteDrugTests;

public class FavoriteDrugNegativeTests
{
    public static IEnumerable<object[]> TestFavoriteDrugValidator = NegativeTestDataGenerator.GetFavoriteDrugValidationExceptionsProperties();

    [Theory]
    [MemberData(nameof(TestFavoriteDrugValidator))]
    public void Add_FavoriteDrug_ThrowValidationException(
        Guid profileId,
        Profile profile,
        Guid drugId,
        Drug drug)
    {
        var drugStore = DrugStoreGenerator.Generator();
        var action = () => new FavoriteDrug( profileId,  profile,  drugId, drugStore.Id, drug, drugStore);

        action.Should().Throw<ValidationException>();
    }

}
