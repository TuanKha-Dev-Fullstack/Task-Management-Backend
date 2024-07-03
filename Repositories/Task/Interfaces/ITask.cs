namespace Task_Management_Backend.Repositories.Task.Interfaces;

public interface ITask
{
    Task<Models.Domains.Task> AddTask(string name);
    Task<List<Models.Domains.Task>> UnfinishedTasks();
}