namespace Task_Management_Backend.Models.Domains;
public class Task : BaseEntity
{
    public bool IsCompeleted { get; set; }
    public bool IsImportant { get; set; }
    public int? CategoryId { get; set; }
    public Categories? Category { get; set; }
}