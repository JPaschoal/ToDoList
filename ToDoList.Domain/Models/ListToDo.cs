using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Models;

public class ListToDo
{
    public ListToDo(String title)
    {
        Title = title;
    }
    
    
    [Key]
    [Required]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public virtual ICollection<ToDoItem>? Items { get; set; }
    public int Status { get; set; }
}