using ToDoList.Domain.Models;

namespace ToDoList.Domain.Dtos.Response;

public class ToDoListResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public IEnumerable<ToDoItemResponse>? Items { get; set; }
}