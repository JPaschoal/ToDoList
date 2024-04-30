namespace ToDoList.Domain.Dtos.Response;

public class ToDoItemResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public bool Done { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}