namespace Domain;

public class AppUser : AuditableEntity
{
    public ICollection<CourseUser> CourseUsers { get; set; }
}