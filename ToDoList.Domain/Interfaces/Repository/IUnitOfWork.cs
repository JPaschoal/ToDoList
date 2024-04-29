namespace ToDoList.Domain.Interfaces.Repository;

public interface IUnitOfWork
{
    IListToDoRepository ListToDo { get; }
    IToDoItemRepository ItemToDo { get; }
    
    Task<bool> CompleteAsync(); 
}