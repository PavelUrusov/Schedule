namespace WorkSchedule.DataAccessLayer.Entities;

public abstract class BaseEntity<TKey>
    where TKey : struct
{
    public virtual TKey Id { get; set; } = default!;
}