namespace EFCoreExample.Models;

public class Classroom
{
    public int ClassroomId { get; set; }
    public string Name { get; set; }

    // EF Navigation Properties
    public virtual ICollection<StudentClassroom> StudentClassrooms { get; set; }
}

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }

    // EF Navigation Properties
    public virtual ICollection<StudentClassroom> StudentClassrooms { get; set; }
}

public class StudentClassroom
{
    public int StudentId { get; set; }
    public int ClassroomId { get; set; }

    // EF Navigation Properties
    public virtual Student Student { get; set; }
    public virtual Classroom Classroom { get; set; }
}