using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Interfaces.Services;
using ToDoList.Domain.Models;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    private readonly IToDoService _toDoService;
    
    public ToDoController(IToDoService toDoService)
    {
        _toDoService = toDoService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var toDos = await _toDoService.GetAllLists();
        return Ok(toDos);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateList([FromBody] ListToDo list)
    {
        await _toDoService.CreateList(list);
        return Ok("List created!");
    }
}