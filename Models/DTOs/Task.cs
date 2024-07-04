namespace Task_Management_Backend.Models.DTOs;

public class Task
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsCompeleted { get; set; }
    public bool IsImportant { get; set; }
    public DateTime Created { get; set; }
}