using EFCoreExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Context;

public interface ISchoolContext
{
    DbSet<Classroom> Classrooms { get; set; }
    DbSet<Student> Students { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}