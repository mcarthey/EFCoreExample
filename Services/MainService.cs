// MainService.cs

using EFCoreExample.Context;

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
            Console.WriteLine("2. List Classrooms");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Add Classroom");
                    break;
                case "2":
                    Console.WriteLine("List Classrooms");
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // AddClassroom and ListClassrooms methods go here...
    private async Task ListClassroomsAsync()
    {
        var classrooms = await _repository.GetAllClassroomsAsync();

        foreach (var classroom in classrooms)
        {
            Console.WriteLine($"ID: {classroom.ClassroomId}, Name: {classroom.Name}");
        }
    }
}