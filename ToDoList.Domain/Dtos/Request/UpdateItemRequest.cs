using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Dtos.Request;

public class UpdateItemRequest
{
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; }
}