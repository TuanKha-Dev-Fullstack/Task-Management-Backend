namespace Task_Management_Backend.Models.Domains;

public class Categories : BaseEntity
{
    public List<Task>? Tasks { get; set; }
}