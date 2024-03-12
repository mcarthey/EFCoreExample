namespace EFCoreExample.Models;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }

    // EF Navigation Properties
    public virtual ICollection<Classroom> Classrooms { get; set; }
}
