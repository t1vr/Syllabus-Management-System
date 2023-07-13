namespace Domain;

public class CourseUser : AuditableEntity
{
    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}
