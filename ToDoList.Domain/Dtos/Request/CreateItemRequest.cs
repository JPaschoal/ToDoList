using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Dtos.Request;

public class CreateItemRequest
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public Guid ListId { get; set; }
}