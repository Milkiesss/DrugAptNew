using DrugsApt.Application.Interfaces.Repositories.DrugRepositories;
using DrugsApt.Domain.Entities;

namespace DrugsApt.Application.Interfaces.Repositories.DrugItemRepositories;
/// <summary>
///  репозиторий DrugItem для записи 
/// </summary>
public interface IDrugItemWriteRepository : IWriteRepository<DrugItem>
{
    IReadOnlyList<DrugItem> ReadRepository { get; }
}