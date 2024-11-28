using DrugsApt.Domain.Interface;

namespace DrugsApt.Domain.Entities;
/// <summary>
/// Базовая сущность 
/// </summary>
public abstract class BaseEntity
{
    private List<IDomainEvent> _domainEvents = new();
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Конструктор инициализирующий новый Id
    /// </summary>
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.AsReadOnly();
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
    /// <summary>
    /// переопределение Equals для сравнения сущностей по Id
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
       if(ReferenceEquals(this, obj))
           return true;
       
       if(obj is null || GetType() != obj.GetType())
           return false;
       
       var other = (BaseEntity)obj;
       return Id.Equals(other.Id);
    }
    
    /// <summary>
    /// переопределение GetHashCode, для сравнения Id
    /// </summary>
    /// <returns>Хэш-код идентификатора</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    
    /// <summary>
    /// оператор сравнения по Id
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>True если идентификаторы равны</returns>
    public static bool operator ==(BaseEntity a, BaseEntity b)
    {
        if(a is null)
            return b is null;
        
        return a.Equals(b);
    }
    /// <summary>
    /// оператор сравнения неравенства по Id
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>True если идентификаторы не равны</returns>
    public static bool operator !=(BaseEntity a, BaseEntity b)
    {
        return !(a == b);
    }
}