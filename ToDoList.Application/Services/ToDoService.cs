using ToDoList.Domain.Interfaces.Repository;
using ToDoList.Domain.Interfaces.Services;
using ToDoList.Domain.Models;

namespace ToDoList.Application.Services;

public class ToDoService : IToDoService
{
    private readonly IListToDoRepository _listToDoRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public ToDoService(IListToDoRepository listToDoRepository, IUnitOfWork unitOfWork)
    {
        _listToDoRepository = listToDoRepository;
        _unitOfWork = unitOfWork;
    }
    
    public Task<IEnumerable<ListToDo>> GetAllLists()
    {
        return _listToDoRepository.All();
    }

    public async Task CreateList(ListToDo listToDo)
    {
        await _unitOfWork.ListToDo.Add(listToDo);
        await _unitOfWork.CompleteAsync();
    }
}