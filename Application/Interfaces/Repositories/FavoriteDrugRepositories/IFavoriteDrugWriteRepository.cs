using DrugsApt.Domain.Entities;

namespace DrugsApt.Application.Interfaces.Repositories.FavoriteDrugRepositories;
/// <summary>
///  репозиторий FavoriteDrug для записи 
/// </summary>
public interface IFavoriteDrugWriteRepository : IWriteRepository<FavoriteDrug>
{
    public IReadOnlyList<FavoriteDrug> ReadRepository { get; }
}