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
    /// <summary>Mark a task as finished</summary>
    /// <param name="id">The id of the task</param>
    /// <returns>The updated task</returns>
    public async Task<Models.Domains.Task?> MarkAsFinished(int id)
    {
        // Get the task by id
        var task = await context.Tasks
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();
        // If the task is not found, return null
        if (task == null)
            return null;
        // Mark the task as finished
        task.IsCompeleted = !task.IsCompeleted;
        await context.SaveChangesAsync();
        return task;
    }
    /// <summary>Get all finished tasks</summary>
    /// <returns>All finished tasks</returns>
    public async Task<List<Models.Domains.Task>> FinishedTasks()
    {
        var finishedTasks = await context.Tasks.Where(t => t.IsCompeleted == true).ToListAsync();
        return finishedTasks;
    }
    /// <summary>Mark a task as important or not</summary>
    /// <param name="id">The id of the task</param>
    /// <returns>The updated task</returns>
    public async Task<Models.Domains.Task?> MarkImportant(int id)
    {
        var task = await context.Tasks.Where(t => t.Id == id).FirstOrDefaultAsync();
        if (task == null)
            return null;
        task.IsImportant = !task.IsImportant;
        await context.SaveChangesAsync();
        return task;
    }
    /// <summary>Get all important tasks</summary>
    /// <returns>All important tasks</returns>
    public async Task<List<Models.Domains.Task>> ImportantTasks()
    {
        var importantTasks = await context.Tasks.Where(t => t.IsImportant == true).ToListAsync();
        return importantTasks;
    }
    /// <summary>Update a task</summary>
    /// <param name="id">The id of the task</param>
    /// <param name="name">New name of the task</param>
    /// <returns>Task updated</returns>
    public async Task<Models.Domains.Task?> UpdateTask(int id, string name)
    {
        var task = await context.Tasks.Where(t => t.Id == id).FirstOrDefaultAsync();
        if (task == null)
            return null;
        task.Name = name;
        await context.SaveChangesAsync();
        return task;
    }
    /// <summary>Deletes a task</summary>
    /// <param name="id">The id of the task</param>
    /// <returns>The deleted task</returns>
    public async Task<Models.Domains.Task?> DeleteTask(int id)
    {
        var task = await context.Tasks.Where(t => t.Id == id).FirstOrDefaultAsync();
        if (task == null)
            return null;
        context.Remove(task);
        await context.SaveChangesAsync();
        return task;
    }
}