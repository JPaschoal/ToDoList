using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Dtos.Request;

public class CreateToDoListRequest
{
    [Required]
    public string? Title { get; set; } = string.Empty;
}