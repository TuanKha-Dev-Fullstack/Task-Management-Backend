using Task_Management_Backend.Models.Domains;

namespace Task_Management_Backend.Repositories.Category.Interfaces;

public interface ICategory
{
    Task<Categories> AddCategory(string name);
    Task<List<Categories>> ListCategory();
    Task<Categories?> UpdateCategory(int id, string name);
    Task<Categories?> DeleteCategory(int id);
}