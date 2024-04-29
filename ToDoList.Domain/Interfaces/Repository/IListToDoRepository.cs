using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces.Repository;

public interface IListToDoRepository
{
    Task<List<ListToDo>> GetAllAsync();
    
    void Create(ListToDo listToDo);
}