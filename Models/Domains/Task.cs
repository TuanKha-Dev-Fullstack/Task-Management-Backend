namespace Task_Management_Backend.Models.Domains;
public class Task : BaseEntity
{
    public bool IsCompeleted { get; set; } = false;
    public bool IsImportant { get; set; } = false;
    public Categories? Categories { get; set; }
}