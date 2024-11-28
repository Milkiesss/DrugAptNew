namespace DrugsApt.Application.Interfaces.Repositories;
/// <summary>
/// репозиторий для записи сущностей
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IWriteRepository<T> where T : class
{
    /// <summary>
    /// Репозиторий нo для операций чтения
    /// </summary>
    IReadOnlyList<T> ReadRepository { get; }
    
    /// <summary>
    /// метод для добавления сущностей
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddAsync(T entity,CancellationToken cancellationToken=default);
    
    /// <summary>
    /// метод для обновления сущности
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateAsync(T entity, CancellationToken cancellationToken=default);
    
    /// <summary>
    /// метод для удаления сущности по идентификатору
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteAsync(Guid Id, CancellationToken cancellationToken=default);
}