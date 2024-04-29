using ToDoList.Domain.Interfaces.Repository;
using ToDoList.Domain.Interfaces.Services;
using ToDoList.Domain.Models;

namespace ToDoList.Application.Services;

public class ToDoService : IToDoService
{
    private readonly IListToDoRepository _listToDoRepository;
    
    public ToDoService(IListToDoRepository listToDoRepository)
    {
        _listToDoRepository = listToDoRepository;
    }
    
    
    public Task<List<ListToDo>> GetAllLists()
    {
        return _listToDoRepository.GetAllAsync();
    }

    public Task CreateList(ListToDo listToDo)
    {
        listToDo.CreatedAt = listToDo.CreatedAt.ToUniversalTime();
        _listToDoRepository.Create(listToDo);
        return Task.CompletedTask;
    }
}