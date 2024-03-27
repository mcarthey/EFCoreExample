// MainService.cs

using EFCoreExample.Contexts.Repositories;
using EFCoreExample.Helpers;
using EFCoreExample.Models;

namespace EFCoreExample.Services;

public class MainService
{
    private readonly ISchoolRepository _repository;
    private readonly IConsoleService _consoleService;

    public MainService(ISchoolRepository repository, IConsoleService consoleService)
    {
        _repository = repository;
        _consoleService = consoleService;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            _consoleService.WriteLine("1. Add Classroom");
            _consoleService.WriteLine("2. Add Student to Classroom");
            _consoleService.WriteLine("3. List Classrooms");
            _consoleService.WriteLine("4. List Students in Classroom");
            _consoleService.WriteLine("5. Exit");
            _consoleService.Write("Select an option: ");
            var option = _consoleService.ReadLine();

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
                    _consoleService.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public async Task AddClassroomAsync()
    {
        _consoleService.Write("Enter the name of the new classroom: ");
        var name = _consoleService.ReadLine();

        var newClassroom = new Classroom {Name = name};
        var addedClassroom = await _repository.AddClassroomAsync(newClassroom);

        _consoleService.WriteLine($"Added new classroom with ID: {addedClassroom.ClassroomId}, Name: {addedClassroom.Name}");
    }

    public async Task AddStudentToClassroomAsync()
    {
        _consoleService.Write("Enter the ID of the classroom: ");
        var classroomId = int.Parse(_consoleService.ReadLine());

        _consoleService.Write("Enter the name of the new student: ");
        var name = _consoleService.ReadLine();

        var newStudent = new Student {Name = name};
        await _repository.AddStudentToClassroomAsync(classroomId, newStudent);

        _consoleService.WriteLine($"Added new student with Name: {newStudent.Name} to classroom with ID: {classroomId}");
    }

    public async Task ListClassroomsAsync()
    {
        var classrooms = await _repository.GetAllClassroomsAsync();

        foreach (var classroom in classrooms)
        {
            _consoleService.WriteLine($"ID: {classroom.ClassroomId}, Name: {classroom.Name}");
        }
    }

    public async Task ListStudentsInClassroomAsync()
    {
        _consoleService.Write("Enter the ID of the classroom: ");
        var classroomId = int.Parse(_consoleService.ReadLine());

        var students = await _repository.GetStudentsInClassroomAsync(classroomId);

        foreach (var student in students)
        {
            _consoleService.WriteLine($"ID: {student.StudentId}, Name: {student.Name}");
        }
    }
}
