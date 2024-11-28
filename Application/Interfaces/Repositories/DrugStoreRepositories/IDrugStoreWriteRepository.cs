using DrugsApt.Domain.Entities;

namespace DrugsApt.Application.Interfaces.Repositories.DrugStoreRepositories;
/// <summary>
///  репозиторий DrugStore для записи 
/// </summary>
public interface IDrugStoreWriteRepository : IWriteRepository<DrugStore>
{
    public IReadOnlyList<DrugStore> ReadRepository { get; }
}