using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Interfaces.Repository;
using ToDoList.Domain.Models;

namespace ToDoList.Data.Repositorys;

public class ListToDoRepository : IListToDoRepository
{
    private readonly ToDoContext _context;
    
    public ListToDoRepository(ToDoContext context)
    {
        _context = context;
    }

    public Task<List<ListToDo>> GetAllAsync()
    {
        return _context.ToDoLists.ToListAsync();   
    }

    public void Create(ListToDo listToDo)
    {
         _context.ToDoLists.Add(listToDo);
        _context.SaveChanges();
    }
}