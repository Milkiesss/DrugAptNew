using Microsoft.AspNetCore.OData.Query;
namespace DrugsApt.Application.Interfaces.Repositories;
/// <summary>
/// Репозиторий на чтение сущностей
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IReadRepository<T> where T : class
{
    /// <summary>
    /// Получения сущности по идентификатору
    /// </summary>
    /// <param name="Id">Идентификатор</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<T> GetByIdAsync(Guid? Id, CancellationToken cancellationToken = default); 
    
    /// <summary>
    /// Получение запроса с помощью OData
    /// </summary>
    /// <param name="Id">Идентификатор</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IQueryable> GetQueryableAsync(ODataQueryOptions<T> queryOptions, CancellationToken cancellationToken=default);
}