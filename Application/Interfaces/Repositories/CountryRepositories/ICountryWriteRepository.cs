using DrugsApt.Domain.Entities;

namespace DrugsApt.Application.Interfaces.Repositories.CountryRepositories;
/// <summary>
///  репозиторий Country для записи 
/// </summary>
public interface ICountryWriteRepository : IWriteRepository<Country>
{
    public IReadOnlyList<Country> ReadRepository { get; }
}