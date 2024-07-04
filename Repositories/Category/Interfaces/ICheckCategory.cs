namespace Task_Management_Backend.Repositories.Category.Interfaces;

public interface ICheckCategory
{
    Task<bool> CheckCategory(int id);
}