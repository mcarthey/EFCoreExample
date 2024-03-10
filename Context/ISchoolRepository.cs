using EFCoreExample.Models;

namespace EFCoreExample.Context;

public interface ISchoolRepository
{
    Task<List<Classroom>> GetAllClassroomsAsync();
    Task<Classroom> GetClassroomByIdAsync(int id);
    Task<Classroom> AddClassroomAsync(Classroom classroom);
    Task<Classroom> UpdateClassroomAsync(Classroom classroom);
    Task DeleteClassroomAsync(int id);
}