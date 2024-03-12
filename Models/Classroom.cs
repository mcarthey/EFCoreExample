namespace EFCoreExample.Models;
public class Classroom
{
    public int ClassroomId { get; set; }
    public string Name { get; set; }

    // EF Navigation Properties
    public virtual ICollection<Student> Students { get; set; }
}