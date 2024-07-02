using Task_Management_Backend.Data;
using Task_Management_Backend.Models.Domains;
using Task_Management_Backend.Repositories.Category.Interfaces;

namespace Task_Management_Backend.Repositories.Category.Queries;

public class QCategory(AppDbContext context) : ICategory
{
    /// <summary>Handle add new category</summary>
    /// <param name="name">the name of the category</param>
    /// <returns>the newly created category</returns>
    public async Task<Categories> AddCategory(string name)
    {
        var category = new Categories
        {
            Name = name
        };
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
        return category;
    }
}