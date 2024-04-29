using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Models;

public class ToDoItem
{
    [Key] 
    [Required] 
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = string.Empty;
    
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public int Status { get; set; }
    public virtual Guid ListId { get; set; }
    public virtual ListToDo? List { get; set; }
}