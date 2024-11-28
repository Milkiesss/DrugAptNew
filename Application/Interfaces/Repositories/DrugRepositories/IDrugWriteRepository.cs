using DrugsApt.Domain.Entities;

namespace DrugsApt.Application.Interfaces.Repositories.DrugRepositories;
/// <summary>
///  репозиторий Drug для записи 
/// </summary>
public interface IDrugWriteRepository : IWriteRepository<Drug>
{
    public IReadOnlyList<Drug> ReadRepository { get; }
}