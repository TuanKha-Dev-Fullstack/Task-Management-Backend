using Microsoft.EntityFrameworkCore;
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
    /// <summary>Get all unfinished tasks</summary>
    /// <returns>List of all unfinished tasks</returns>
    public async Task<List<Models.Domains.Task>> UnfinishedTasks()
    {
        var unfinishedTask = await context.Tasks
            .Where(t => t.IsCompeleted == false)
            .OrderByDescending(t => t.Created)
            .ToListAsync();
        return unfinishedTask;
    }
}