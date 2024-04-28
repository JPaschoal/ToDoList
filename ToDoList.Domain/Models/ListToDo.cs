using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Models;

public class ListToDo
{ 
    public ListToDo(String title)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        Title = title;
    }
    
    [Key]
    [Required]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<ToDoItem>? Items { get; set; }
}