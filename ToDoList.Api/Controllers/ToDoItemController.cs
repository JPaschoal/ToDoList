using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Dtos.Request;
using ToDoList.Domain.Interfaces.Services;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemController : ControllerBase
{
    private readonly IToDoItemService _toDoItemService;
    
    public ToDoItemController(IToDoItemService toDoItemService)
    {
        _toDoItemService = toDoItemService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemById(Guid id)
    {
        var items = await _toDoItemService.GetItemById(id);
        return Ok(items);
    }
    
    [HttpPost("items")]
    public async Task<IActionResult> AddItem([FromBody] CreateItemRequest item)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var response = await _toDoItemService.AddItem(item);
        if(response == null)
            return NotFound();
        
        return CreatedAtAction(nameof(GetItemById), new { id = response.Id }, response);
    }
    
    [HttpGet("items")]
    public async Task<IActionResult> GetAllItems()
    {
        var items = await _toDoItemService.GetAllItems();
        return Ok(items);
    }
    
    [HttpPut("items/{id}")]
    public async Task<IActionResult> UpdateItem(Guid id, [FromBody] UpdateItemRequest item)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var response = await _toDoItemService.UpdateItem(id, item);
        if(response == null)
            return NotFound();
        
        return Ok("Updated successfully!");
    }
    
    [HttpDelete("items/{id}")]
    public async Task<IActionResult> DeleteItem(Guid id)
    {
        var response = await _toDoItemService.DeleteItem(id);
        if(response == null)
            return NotFound();
        
        return NoContent();
    }
    
    [HttpGet("{listId}/items")]
    public async Task<IActionResult> GetItemsByListId(Guid listId)
    {
        var items = await _toDoItemService.GetAllItemsByListId(listId);
        return Ok(items);
    }
}