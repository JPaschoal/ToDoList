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
        return await _dbset.Where(x => x.ListId == listId)
            .AsNoTracking()
            .AsSplitQuery()
            .OrderBy(x => x.CreatedAt)
            .ToListAsync();
    }

    public override async Task<IEnumerable<ToDoItem>> All()
    {
        return await _dbset.Where(x => x.Status == 1)
            .AsNoTracking()
            .AsSplitQuery()
            .OrderBy(x => x.CreatedAt)
            .ToListAsync();
    }
    
    public override async Task<bool> Delete(Guid id)
    {
        var result = await _dbset.FirstOrDefaultAsync(x => x.Id == id);
        if (result == null) 
            return false;
            
        result.Status = 0;
        result.UpdatedAt = DateTime.UtcNow;
            
        return true;
    }
    
    public override async Task<bool> Update(ToDoItem entity)
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
}