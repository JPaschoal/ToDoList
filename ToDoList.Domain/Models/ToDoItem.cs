using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Models;

public class ToDoItem
{
    public ToDoItem()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }
    
    [Key]
    [Required]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = string.Empty;
    
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public virtual Guid ListId { get; set; }
}