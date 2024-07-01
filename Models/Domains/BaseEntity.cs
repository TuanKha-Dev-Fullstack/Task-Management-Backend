using System.ComponentModel.DataAnnotations;

namespace Task_Management_Backend.Models.Domains;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; init; }
    public required string Name { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
}