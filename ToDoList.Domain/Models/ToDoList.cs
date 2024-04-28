namespace ToDoList.Domain.Models;

public class ToDoList
{  
public Guid Id { get; set; }
    public string Title { get; set; }
    public virtual ICollection<ToDoItem> Items { get; set; }
}