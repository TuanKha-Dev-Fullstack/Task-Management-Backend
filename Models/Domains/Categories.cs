using System.ComponentModel.DataAnnotations;

namespace Task_Management_Backend.Models.Domains;

public abstract class Categories
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<TasksInCategory>? TasksInCategory { get; set; }
}