using Task_Management_Backend.Data;
using Task_Management_Backend.Repositories.Task.Interfaces;
namespace Task_Management_Backend.Repositories.Task.Queries;

public class QTask(AppDbContext context) : ITask
{
    /// <summary>Handle saves a new task</summary>
    /// <param name="name">name of the new task</param>
    /// <returns>Returns the newly created task</returns>
    public async Task<Models.Domains.Task> AddTask(string name)
    {
        var newTask = new Models.Domains.Task
        {
            Name = name
        };
        await context.Tasks.AddAsync(newTask);
        await context.SaveChangesAsync();
        return newTask;
    }
}