using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Interfaces.Repository;

namespace ToDoList.Data.Repository;

public class GenericRopository<T> : IGenericRepository<T> where T : class
{
    protected ToDoContext _context;
    internal DbSet<T> _dbset;
    
    public GenericRopository(ToDoContext context)
    {
        _context = context;
          
        _dbset = _context.Set<T>();
    }
    
    
    public virtual Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await _dbset.FindAsync(id);
    }

    public virtual async Task<bool> Add(T entity)
    {
        var response = await _dbset.AddAsync(entity);
        return true;
    }

    public virtual Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}