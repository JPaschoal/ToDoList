using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Models;

public class ToDoList
{  
    public ToDoList()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }
    [Key]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<ToDoItem> Items { get; set; }
}