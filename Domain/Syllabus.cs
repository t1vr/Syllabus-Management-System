namespace Domain;

public class Syllabus : AuditableEntity<int>
{
    public string Title { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}