namespace Domain;

public class AppUser : AuditableEntity
{
    private AppUser(Guid id)
    {
        Id = id;
    }
    public new Guid Id { get; private set; }
    public ICollection<CourseUser> CourseUsers { get; set; }
    public static AppUser CreateUser(string id)
    {
        return new AppUser(Guid.Parse(id));
    }
}