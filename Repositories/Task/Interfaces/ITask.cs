namespace Task_Management_Backend.Repositories.Task.Interfaces;

public interface ITask
{
    // Add a new task
    Task<Models.Domains.Task> AddTask(string name, int? categoryId);
    // Get all unfinished tasks
    Task<List<Models.DTOs.Task>> UnfinishedTasks();
    // Mark a task as finished
    Task<Models.Domains.Task?> MarkAsFinished(int id);
    // Get all finished tasks
    Task<List<Models.DTOs.Task>> FinishedTasks();
    // Mark a task as important or not
    Task<Models.Domains.Task?> MarkImportant(int id);
    // Get all important tasks
    Task<List<Models.DTOs.Task>> ImportantTasks();
    // Update a task
    Task<Models.Domains.Task?> UpdateTask(int id, string name);
    // Delete a task
    Task<Models.Domains.Task?> DeleteTask(int id);
    // Get tasks by category
    Task<List<Models.DTOs.Task>?> TasksByCategory(int categoryId);
}