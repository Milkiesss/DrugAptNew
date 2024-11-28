using Bogus;
using DrugsApt.Domain.Entities;

namespace DrugsApt.Tests.Generators;

public class DrugGenerator
{
    private static readonly Faker<Drug> _fakerDrug = new Faker<Drug>()
        .CustomInstantiator(d =>
        {
            var country = CoutryGenerator.Generator();
            return new Drug(
                d.Random.String2(1, 150),
                d.Random.String2(1, 100),
                country.Code,
                country
            );
        });

    public static Drug Generator()
    {
        return _fakerDrug.Generate();
    }
}