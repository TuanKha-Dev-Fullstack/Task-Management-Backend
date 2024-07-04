namespace Task_Management_Backend.Repositories.Category.Interfaces;

public interface ICheckCategory
{
    // Checks if category exists
    Task<bool> CheckCategory(int id);
}