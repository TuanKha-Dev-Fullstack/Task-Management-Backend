namespace Task_Management_Backend.Models.Domains;

public class Categories
{
    [key]
    public int id { get; set; }
    public string name { get; set; }
    public List<TasksInCategory>? tasks_in_category { get; set; }
}