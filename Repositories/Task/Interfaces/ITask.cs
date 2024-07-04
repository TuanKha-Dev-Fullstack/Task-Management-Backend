namespace Task_Management_Backend.Repositories.Task.Interfaces;

public interface ITask
{
    Task<Models.Domains.Task> AddTask(string name);
    Task<List<Models.Domains.Task>> UnfinishedTasks();
    Task<Models.Domains.Task?> MarkAsFinished(int id);
    Task<List<Models.Domains.Task>> FinishedTasks();
    Task<Models.Domains.Task?> MarkImportant(int id);
    Task<List<Models.Domains.Task>> ImportantTasks();
    Task<Models.Domains.Task?> UpdateTask(int id, string name);
    Task<Models.Domains.Task?> DeleteTask(int id);
}