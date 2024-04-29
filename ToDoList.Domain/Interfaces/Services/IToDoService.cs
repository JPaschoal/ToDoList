using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces.Services;

public interface IToDoService
{
    Task<List<ListToDo>> GetAllLists();
    Task CreateList(ListToDo listToDo);
}