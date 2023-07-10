namespace Domain;

public class Program : AuditableEntity<int>
{
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public ICollection<Course> Courses { get; set; }
}
