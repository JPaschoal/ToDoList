using ToDoList.Domain.Dtos.Request;
using ToDoList.Domain.Dtos.Response;

namespace ToDoList.Domain.Interfaces.Services;

public interface IToDoItemService
{
    // ToDo items operations
    Task<ToDoItemResponse?> AddItem(CreateItemRequest item);
    Task<ToDoItemResponse?> GetItemById(Guid id);
    Task<IEnumerable<ToDoItemResponse>> GetAllItemsByListId(Guid listId);
    Task<IEnumerable<ToDoItemResponse>> GetAllItems();
    Task<ToDoItemResponse?> UpdateItem(Guid id, UpdateItemRequest task);
    Task<ToDoItemResponse?> DeleteItem(Guid id);
}