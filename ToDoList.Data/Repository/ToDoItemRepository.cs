using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Interfaces.Repository;
using ToDoList.Domain.Models;

namespace ToDoList.Data.Repository;

public class ToDoItemRepository : GenericRopository<ToDoItem>, IToDoItemRepository
{
    public ToDoItemRepository(ToDoContext context) : base(context)
    { }

    public async Task<IEnumerable<ToDoItem>> GetByListId(Guid listId)
    {
        try
        {
            return await _dbset.Where(x => x.ListId == listId)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();
        }
        catch (Exception e)
        {
            //_logger.LogError(e, message: "{Repo} GetByListId method error", typeof(ToDoItemRepository));
            throw;
        }
    }

    public override async Task<IEnumerable<ToDoItem>> All()
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
            //_logger.LogError(e, message: "{Repo} Delete method error", typeof(ListToDoRepository));
            throw;
        }
    }
    
    public override async Task<bool> Update(ToDoItem entity)
    {
        try
        {
            var result = await _dbset.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (result == null)
                return false;
            
            result.Title = entity.Title;
            result.UpdatedAt = DateTime.UtcNow;
            result.IsDone = entity.IsDone;
            result.CompletedAt = entity.CompletedAt;
            
            return true;
        }
        catch (Exception e)
        {
            //_logger.LogError(e, message: "{Repo} Update method error", typeof(ListToDoRepository));
            throw;
        }
    }
}