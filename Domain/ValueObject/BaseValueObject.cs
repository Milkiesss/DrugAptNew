using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace DrugsApt.Domain.ValueObject;
/// <summary>
/// базовый класс для всех обьектов значений, обеспечивающих сравнение и вычисление хэш-кода на основе всех полей и свойств
/// </summary>
public abstract class BaseValueObject : IEquatable<BaseValueObject>
{
    /// <summary>
    /// Определяет равен ли текущий обьект значению другого обьекта
    /// </summary>
    /// <param name="other">друго2 обьекта</param>
    /// <returns></returns>
    public bool Equals(BaseValueObject? other)
    {
        if(other == null || GetType() != other.GetType())
            return false;
        foreach (var property in GetType().GetProperties())
        {
            var value1 = property.GetValue(this);
            var value2 = property.GetValue(other);
            if(!Equals(value1, value2))
                return false;
        }

        foreach (var field in GetType().GetFields())
        {
            var value1 = field.GetValue(this);
            var value2 = field.GetValue(other);

            if (!Equals(value1, value2))
                return false;
        }
        return true;
    }
    
    /// <summary>
    /// переопределение метода Equals для сравнения обьектов
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return Equals(obj as BaseValueObject);
    }

    /// <summary>
    /// переопределение метода GetHashCode для вычисления хэш-кода на основе всех полей и свойств
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        int hash = 17;
        foreach (var property in GetType().GetProperties())
        {
            var value = property.GetValue(this);
            hash = (hash * 31) + value?.GetHashCode() ?? 0;
        }

        foreach (var field in GetType().GetFields())
        {
            var value = field.GetValue(this);
            hash = (hash * 31) + value?.GetHashCode() ?? 0;
        }
        return hash;
    }
    /*т.е 17 и 31 используются для лучшей вариативности хэшей, особенно в случаях, если значения одинаковы умножение на нечетное числa 
    (17 в начале процесса и 31) дает больше "случайности"  и уменьшает кол-во коллзий*/




    /// <summary>
    /// получает список всех доступных полей обьекта для сравнения
    /// </summary>
    /// <returns>коллекция свойств обьекта</returns>
    public IEnumerable<PropertyInfo> GetProperties()
    {
        return GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p=>p.GetGetMethod()!.IsVirtual);
    }

    /// <summary>
    /// получает список всех доступных полуй обьекта для сравнения
    /// </summary>
    /// <returns>коллекция полей обьекта</returns>
    public IEnumerable<FieldInfo> GetFields()
    {
        return GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
    }

    /// <summary>
    /// оператор сравнения на равенство для обьектов значения
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>True, если обьекты равны</returns>
    public static bool operator ==(BaseValueObject? a, BaseValueObject? b)
    {
        return a?.Equals(b) ?? ReferenceEquals(b, null);
    }

    /// <summary>
    /// оператор сравнения на не равенство для обьектов значения
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>True, если обьекты не равны</returns>
    public static bool operator !=(BaseValueObject? a, BaseValueObject? b)
    {
        return !(a == b);
    }
}