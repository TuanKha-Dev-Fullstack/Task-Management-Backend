using Task_Management_Backend.Data;
using Task_Management_Backend.Repositories.Category.Interfaces;

namespace Task_Management_Backend.Repositories.Category.Queries;

public class QCheckCategory(AppDbContext context) : ICheckCategory
{
    public async Task<bool> CheckCategory(int id)
    {
        var checkCategory = await context.Categories.FindAsync(id);
        return checkCategory != null;
    }
}