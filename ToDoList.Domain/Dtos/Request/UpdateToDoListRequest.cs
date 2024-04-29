using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Dtos.Request;

public class UpdateToDoListRequest
{ 
    [Required] 
    public string? Title { get; set; } = string.Empty;
}