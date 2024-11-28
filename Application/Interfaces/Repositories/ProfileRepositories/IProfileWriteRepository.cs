using DrugsApt.Domain.Entities;

namespace DrugsApt.Application.Interfaces.Repositories.ProfileRepositories;
/// <summary>
/// репозиторий Profile для записи 
/// </summary>
public interface IProfileWriteRepository : IWriteRepository<Profile>
{
    IReadOnlyList<Profile> ReadRepository { get; }
}