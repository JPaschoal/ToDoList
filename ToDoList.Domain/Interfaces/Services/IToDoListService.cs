using ToDoList.Domain.Dtos.Request;
using ToDoList.Domain.Dtos.Response;

namespace ToDoList.Domain.Interfaces.Services;

public interface IToDoListService
{
    // ToDo lists operations
    Task<IEnumerable<ToDoListResponse>> GetAllLists();
    Task<ToDoListResponse> CreateList(CreateToDoListRequest listToDo);
    Task<ToDoListResponse> GetById(Guid id);
    Task<ToDoListResponse?> UpdateList(Guid id, UpdateToDoListRequest listToDo);
    Task<ToDoListResponse?> Delete(Guid id);
}