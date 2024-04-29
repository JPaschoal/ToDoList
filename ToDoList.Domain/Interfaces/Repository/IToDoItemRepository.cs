using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces.Repository;

public interface IToDoItemRepository
{
    void AddAsync(ToDoItem toDoItem);
    Task<List<ToDoItem>> GetAllAsync();
}