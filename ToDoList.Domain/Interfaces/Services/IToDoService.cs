using ToDoList.Domain.Dtos.Request;
using ToDoList.Domain.Dtos.Response;

namespace ToDoList.Domain.Interfaces.Services;

public interface IToDoService
{
    // ToDo lists operations
    Task<IEnumerable<ToDoListResponse>> GetAllLists();
    Task<ToDoListResponse> CreateList(CreateToDoListRequest listToDo);
    Task<ToDoListResponse> GetById(Guid id);
    Task<ToDoListResponse?> UpdateList(Guid id, UpdateToDoListRequest listToDo);
    Task<ToDoListResponse?> Delete(Guid id);
    
    // ToDo items operations
    Task<ToDoItemResponse?> AddItem(CreateItemRequest item);
    Task<ToDoItemResponse?> GetItems(Guid id);
    Task<IEnumerable<ToDoItemResponse>> GetAllItemsByListId(Guid listId);
    Task<IEnumerable<ToDoItemResponse>> GetAllItems();
    Task<ToDoItemResponse?> UpdateItem(Guid id, UpdateItemRequest task);
    Task<ToDoItemResponse?> DeleteItem(Guid id);
}