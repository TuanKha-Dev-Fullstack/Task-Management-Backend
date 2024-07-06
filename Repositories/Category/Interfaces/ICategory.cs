using Task_Management_Backend.Models.Domains;

namespace Task_Management_Backend.Repositories.Category.Interfaces;

public interface ICategory
{
    // Add Category
    Task<Categories> AddCategory(string name);
    // Get Category list
    Task<List<Models.DTOs.Category>> ListCategory();
    // Update Category
    Task<Categories?> UpdateCategory(int id, string name);
    // Delete Category
    Task<Categories?> DeleteCategory(int id);
}