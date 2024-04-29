using Microsoft.Extensions.Logging;
using ToDoList.Domain.Interfaces.Repository;

namespace ToDoList.Data.Repository;

public class UnitOfWork : IUnitOfWork, IDisposable
{
     private readonly ToDoContext _context;
    
    public IListToDoRepository ListToDo { get; }
    public IToDoItemRepository ItemToDo { get; }
    
    public UnitOfWork(ToDoContext context)
    {    
        _context = context;

        ListToDo = new ListToDoRepository(_context);
        ItemToDo = new ToDoItemRepository(_context);
    }
    
    public async Task<bool> CompleteAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}