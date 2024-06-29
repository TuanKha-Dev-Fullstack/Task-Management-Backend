using System.ComponentModel.DataAnnotations;

namespace Task_Management_Backend.Models.Domains;

public abstract class TasksInCategory
{
    [Key]
    public int TaskId { get; set; }
    public Task? Tasks { get; set; }
    [Key]
    public int CategoryId { get; set; }
    public Categories? Categories { get; set; }
}