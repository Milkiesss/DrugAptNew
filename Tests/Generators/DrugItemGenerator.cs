using Bogus;
using DrugsApt.Domain.Entities;

namespace DrugsApt.Tests.Generators;

public class DrugItemGenerator
{
    private static Drug drug = DrugGenerator.Generator();
    private static DrugStore drugStore = DrugStoreGenerator.Generator();
        
    private static readonly Faker<DrugItem> _fakerDrugItem = new Faker<DrugItem>()
        .CustomInstantiator(d =>
        {
            return new DrugItem(drug.Id,
                drug,
                drugStore.Id,
                drugStore,
                Math.Round(d.Random.Decimal(1, 100)),
                d.Random.Double(1,100)
            );
        });

    public static DrugItem Generator()
    {
        return _fakerDrugItem.Generate();
    }
}