namespace Task_Management_Backend.Models.Domains;

public class Categories : BaseEntity
{
    // Navigation Properties
    public List<Task>? Tasks { get; set; }
}