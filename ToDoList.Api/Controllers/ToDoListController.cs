using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Dtos.Request;
using ToDoList.Domain.Interfaces.Services;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoListController : ControllerBase
{
    private readonly IToDoService _toDoService;
    
    public ToDoListController(IToDoService toDoService)
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
    
    [HttpGet("{id}/items")]
    public async Task<IActionResult> GetItemsByListId(Guid id)
    {
        var items = await _toDoService.GetAllItemsByListId(id);
        return Ok(items);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateList([FromBody] CreateToDoListRequest list)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
         
        var response = await _toDoService.CreateList(list);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateList(Guid id, [FromBody] UpdateToDoListRequest list)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var response = await _toDoService.UpdateList(id, list);
        if(response == null)
            return NotFound();
        
        return Ok("Updated successfully!");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _toDoService.Delete(id);
        if(response == null)
            return NotFound();
        
        return NoContent();
    }
    
    [HttpGet("items/{id}")]
    public async Task<IActionResult> GetItems(Guid id)
    {
        var items = await _toDoService.GetItems(id);
        return Ok(items);
    }
    
    [HttpPost("items")]
    public async Task<IActionResult> AddItem([FromBody] CreateItemRequest item)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var response = await _toDoService.AddItem(item);
        if(response == null)
            return NotFound();
        
        return CreatedAtAction(nameof(GetItems), new { id = response.Id }, response);
    }
    
    [HttpGet("items")]
    public async Task<IActionResult> GetAllItems()
    {
        var items = await _toDoService.GetAllItems();
        return Ok(items);
    }
    
    [HttpPut("items/{id}")]
    public async Task<IActionResult> UpdateItem(Guid id, [FromBody] UpdateItemRequest item)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var response = await _toDoService.UpdateItem(id, item);
        if(response == null)
            return NotFound();
        
        return Ok("Updated successfully!");
    }
    
    [HttpDelete("items/{id}")]
    public async Task<IActionResult> DeleteItem(Guid id)
    {
        var response = await _toDoService.DeleteItem(id);
        if(response == null)
            return NotFound();
        
        return NoContent();
    }
}