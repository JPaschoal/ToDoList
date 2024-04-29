using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Interfaces.Repository;
using ToDoList.Domain.Models;

namespace ToDoList.Data.Repository;

public class ListToDoRepository : GenericRopository<ListToDo>, IListToDoRepository
{
    public ListToDoRepository(ToDoContext context) : base(context)
    { }
    
    public override async Task<IEnumerable<ListToDo>> All()
    {
        try
        {
            return await _dbset.Where(x => x.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();
        }
        catch (Exception e)
        {
            //_logger.LogError(e, message: "{Repo} All method error", typeof(ListToDoRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var result = await _dbset.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
                return false;
            
            result.Status = 0;
            result.UpdatedAt = DateTime.UtcNow;
            
            return true;
        }
        catch (Exception e)
        {
           // _logger.LogError(e, message: "{Repo} Delete method error", typeof(ListToDoRepository));
            throw;
        }
    }
    
    public override async Task<bool> Update(ListToDo entity)
    {
        try
        {
            var result = await _dbset.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (result == null)
                return false;
            
            result.Title = entity.Title;
            result.UpdatedAt = DateTime.UtcNow;
            
            return true;
        }
        catch (Exception e)
        {
            //_logger.LogError(e, message: "{Repo} Update method error", typeof(ListToDoRepository));
            throw;
        }
    }
}