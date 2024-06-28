namespace Task_Management_Backend.Models.Domains;
public class Task
{
    [Key]
    public int id { get; set; }
    public string name { get; set; }
    public DateTime created { get; set; }
    public bool is_compeleted { get; set; }
    public bool is_important { get; set }
    public List<TasksInCategory>? tasks_in_category { get; set; }
}