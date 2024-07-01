using System.ComponentModel.DataAnnotations;

namespace Task_Management_Backend.Models.Domains;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; init; }

    [Required(ErrorMessage = "Name field is required")]
    [MaxLength(255, ErrorMessage = "Name field cannot exceed 255 characters")]
    public required string Name { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
}