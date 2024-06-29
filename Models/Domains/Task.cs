using System.ComponentModel.DataAnnotations;

namespace Task_Management_Backend.Models.Domains;
public abstract class Task
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime Created { get; set; }
    public bool IsCompeleted { get; set; }
    public bool IsImportant { get; set; }
    public List<TasksInCategory>? TasksInCategory { get; set; }
}