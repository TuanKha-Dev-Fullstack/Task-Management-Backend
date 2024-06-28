namespace Task_Management_Backend.Models.Domains;

public class TasksInCategory
{
    [Key]
    public int task_id { get; set; }
    public Task? tasks { get; set; }
    [Key]
    public int category_id { get; set; }
    public Categories? categories { get; set; }
}