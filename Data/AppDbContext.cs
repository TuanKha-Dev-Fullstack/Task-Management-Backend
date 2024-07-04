using Microsoft.EntityFrameworkCore;
using Task_Management_Backend.Models.Domains;
using Task = Task_Management_Backend.Models.Domains.Task;

namespace Task_Management_Backend.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>()
            .HasOne(t => t.Category)
            .WithMany(c => c.Tasks)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Categories> Categories { get; set; }
}