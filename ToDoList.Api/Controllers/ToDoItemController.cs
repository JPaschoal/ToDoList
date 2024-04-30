using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Dtos.Request;
using ToDoList.Domain.Interfaces.Services;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemController : ControllerBase
{
    private IToDoService _toDoService;
    
    public ToDoItemController(IToDoService toDoService)
    {
        _toDoService = toDoService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItems(Guid id)
    {
        var items = await _toDoService.GetItems(id);
        return Ok(items);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddItem([FromBody] CreateItemRequest item)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var response = await _toDoService.AddItem(item);
        if(response == null)
            return NotFound();
        
        return CreatedAtAction(nameof(GetItems), new { id = response.Id }, response);
    }
}