using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Dtos.Request;
using ToDoList.Domain.Interfaces.Services;

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
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var toDo = await _toDoService.GetById(id);
        return Ok(toDo);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var toDos = await _toDoService.GetAllLists();
        return Ok(toDos);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateList([FromBody] CreateToDoListRequest list)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
         
        var response = await _toDoService.CreateList(list);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }
}