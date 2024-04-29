using ToDoList.Domain.Models;

namespace ToDoList.Domain.Interfaces.Repository;

public interface IToDoItemRepository : IGenericRepository<ToDoItem>
{
    Task<IEnumerable<ToDoItem>> GetByListId(Guid listId);
}