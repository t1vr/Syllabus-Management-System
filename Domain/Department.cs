namespace Domain;

public class Department : AuditableEntity<int>
{
    public string Name { get; set; }
    public ICollection<Program> Programs { get; set; }
}
