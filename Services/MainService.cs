// MainService.cs

using EFCoreExample.Contexts.Repositories;
using EFCoreExample.Models;

namespace EFCoreExample.Services;

public class MainService
{
    private readonly ISchoolRepository _repository;

    public MainService(ISchoolRepository repository)
    {
        _repository = repository;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("1. Add Classroom");
            Console.WriteLine("2. Add Student to Classroom");
            Console.WriteLine("3. List Classrooms");
            Console.WriteLine("4. List Students in Classroom");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await AddClassroomAsync();
                    break;
                case "2":
                    await AddStudentToClassroomAsync();
                    break;
                case "3":
                    await ListClassroomsAsync();
                    break;
                case "4":
                    await ListStudentsInClassroomAsync();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private async Task AddClassroomAsync()
    {
        Console.Write("Enter the name of the new classroom: ");
        var name = Console.ReadLine();

        var newClassroom = new Classroom {Name = name};
        var addedClassroom = await _repository.AddClassroomAsync(newClassroom);

        Console.WriteLine($"Added new classroom with ID: {addedClassroom.ClassroomId}, Name: {addedClassroom.Name}");
    }

    private async Task AddStudentToClassroomAsync()
    {
        Console.Write("Enter the ID of the classroom: ");
        var classroomId = int.Parse(Console.ReadLine());

        Console.Write("Enter the name of the new student: ");
        var name = Console.ReadLine();

        var newStudent = new Student {Name = name};
        await _repository.AddStudentToClassroomAsync(classroomId, newStudent);

        Console.WriteLine($"Added new student with Name: {newStudent.Name} to classroom with ID: {classroomId}");
    }

    private async Task ListClassroomsAsync()
    {
        var classrooms = await _repository.GetAllClassroomsAsync();

        foreach (var classroom in classrooms)
        {
            Console.WriteLine($"ID: {classroom.ClassroomId}, Name: {classroom.Name}");
        }
    }

    private async Task ListStudentsInClassroomAsync()
    {
        Console.Write("Enter the ID of the classroom: ");
        var classroomId = int.Parse(Console.ReadLine());

        var students = await _repository.GetStudentsInClassroomAsync(classroomId);

        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.StudentId}, Name: {student.Name}");
        }
    }
}
