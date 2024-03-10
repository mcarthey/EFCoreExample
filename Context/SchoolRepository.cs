using EFCoreExample.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreExample.Context
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ISchoolContext _context;

        public SchoolRepository(ISchoolContext context)
        {
            _context = context;
        }

        // CRUD operations for Classroom
        public async Task<List<Classroom>> GetAllClassroomsAsync()
        {
            return await _context.Classrooms.ToListAsync();
        }

        public async Task<Classroom> GetClassroomByIdAsync(int id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom == null)
            {
                throw new Exception($"Classroom with id {id} not found.");
            }

            return classroom;
        }

        public async Task<Classroom> AddClassroomAsync(Classroom classroom)
        {
            _context.Classrooms.Add(classroom);
            await _context.SaveChangesAsync();
            return classroom;
        }

        public async Task<Classroom> UpdateClassroomAsync(Classroom classroom)
        {
            if (_context is DbContext dbContext)
            {
                dbContext.Entry(classroom).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return classroom;
        }

        public async Task DeleteClassroomAsync(int id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom == null)
            {
                throw new Exception($"Classroom with id {id} not found.");
            }

            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();
        }

        // CRUD operations for Student
        // Similar to Classroom, implement GetAllStudentsAsync, GetStudentByIdAsync, AddStudentAsync, UpdateStudentAsync, DeleteStudentAsync
    }
}
