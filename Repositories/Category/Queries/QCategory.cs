using Microsoft.EntityFrameworkCore;
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
    /// <summary>Get all categories</summary>
    /// <returns>List of categories</returns>
    public async Task<List<Models.DTOs.Category>> ListCategory()
    {
        var categories = await context.Categories
            .Select(c => new Models.DTOs.Category()
            {
                Id = c.Id,
                Name = c.Name,
                Created = c.Created
            })
            .ToListAsync();
        return categories;
    }
    /// <summary>Handle update category</summary>
    /// <param name="id">The id of the category</param>
    /// <param name="name">The new name of the category</param>
    /// <returns>The updated category</returns>
    public async Task<Categories?> UpdateCategory(int id, string name)
    {
        var category =  await context.Categories.FindAsync(id);
        if (category == null) return null;
        category.Name = name;
        await context.SaveChangesAsync();
        return category;
    }
    /// <summary>Handle delete category</summary>
    /// <param name="id">The id of the category</param>
    /// <returns>The deleted category</returns>
    public async Task<Categories?> DeleteCategory(int id)
    {
        var category =  await context.Categories.FindAsync(id);
        if (category == null) return null;
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
        return category;
    }
}