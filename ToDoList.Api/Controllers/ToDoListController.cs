using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Dtos.Request;
using ToDoList.Domain.Interfaces.Services;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoListController : ControllerBase
{
    private readonly IToDoListService _toDoListService;
    
    public ToDoListController(IToDoListService toDoListService)
    {
        _toDoListService = toDoListService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var toDo = await _toDoListService.GetById(id);
        return Ok(toDo);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var toDos = await _toDoListService.GetAllLists();
        return Ok(toDos);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateList([FromBody] CreateToDoListRequest list)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
         
        var response = await _toDoListService.CreateList(list);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateList(Guid id, [FromBody] UpdateToDoListRequest list)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var response = await _toDoListService.UpdateList(id, list);
        if(response == null)
            return NotFound();
        
        return Ok("Updated successfully!");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _toDoListService.Delete(id);
        if(response == null)
            return NotFound();
        
        return NoContent();
    }
}