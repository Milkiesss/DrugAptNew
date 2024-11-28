using Bogus;
using DrugsApt.Domain.Entities;
using DrugsApt.Domain.ValueObject;

namespace DrugsApt.Tests.Generators;

public class DrugStoreGenerator
{
    private static readonly Faker<DrugStore> _fakerDrugStore = new Faker<DrugStore>()
        .CustomInstantiator(d => new DrugStore(
            d.Random.String2(1,10000),
            d.Random.Int(1,10),
            new Address(d.Address.StreetName(), d.Address.City(),d.Random.Int(1,10),d.Random.Int(10000,999999)),
            d.Phone.PhoneNumber()
        ));

    public static DrugStore Generator()
    {
        return _fakerDrugStore.Generate();
    }
}