namespace Domain;

public class Course : AuditableEntity
{
    public string CourseNo { get; set; }
    public string Name { get; set; }
    public int ProgramId { get; set; }
    public Program Program { get; set; }
    public ICollection<Syllabus> Syllabuses { get; set; }
    public ICollection<CourseUser> CourseUsers { get; set; }

}
