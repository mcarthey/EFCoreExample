using EFCoreExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Context;

public class SchoolContext : DbContext, ISchoolContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentClassroom> StudentClassrooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentClassroom>()
            .HasKey(sc => new { sc.StudentId, sc.ClassroomId });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}