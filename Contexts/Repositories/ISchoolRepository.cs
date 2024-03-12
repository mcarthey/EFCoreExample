using EFCoreExample.Models;

namespace EFCoreExample.Contexts.Repositories;

public interface ISchoolRepository
{
    Task<List<Classroom>> GetAllClassroomsAsync();
    Task<Classroom> GetClassroomByIdAsync(int id);
    Task<Classroom> AddClassroomAsync(Classroom classroom);
    Task<Classroom> UpdateClassroomAsync(Classroom classroom);
    Task DeleteClassroomAsync(int id);

    // CRUD operations for Student
    Task<List<Student>> GetAllStudentsAsync();
    Task<Student> GetStudentByIdAsync(int id);
    Task<Student> AddStudentAsync(Student student);
    Task<Student> UpdateStudentAsync(Student student);
    Task DeleteStudentAsync(int id);

    // Join operations
    Task AddStudentToClassroomAsync(int classroomId, Student student);
    Task<List<Student>> GetStudentsInClassroomAsync(int classroomId);
}