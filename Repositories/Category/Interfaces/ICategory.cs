using Task_Management_Backend.Models.Domains;

namespace Task_Management_Backend.Repositories.Category.Interfaces;

public interface ICategory
{
    Task<Categories> AddCategory(string name);
}