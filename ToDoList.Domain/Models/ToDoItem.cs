namespace ToDoList.Domain.Models;

public class ToDoItem
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public virtual Guid ListId { get; set; }
}