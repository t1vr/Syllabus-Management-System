namespace Domain;

public abstract class BaseEntity : BaseEntity<Guid>
{
    protected BaseEntity() => Id = Guid.NewGuid();
}

public abstract class BaseEntity<TId>
{
    public TId Id { get; protected set; } = default!;
}
