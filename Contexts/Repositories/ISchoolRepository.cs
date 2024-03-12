using EFCoreExample.Models;

namespace EFCoreExample.Contexts.Repositories;

public interface ISchoolRepository
{
    Task<List<Classroom>> GetAllClassroomsAsync();
    Task<Classroom> GetClassroomByIdAsync(int id);
    Task<Classroom> AddClassroomAsync(Classroom classroom);
    Task<Classroom> UpdateClassroomAsync(Classroom classroom);
    Task DeleteClassroomAsync(int id);
}