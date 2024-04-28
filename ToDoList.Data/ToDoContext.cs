using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Models;

namespace ToDoList.Data;

public class ToDoContext : DbContext
{
    public ToDoContext (DbContextOptions<ToDoContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ToDoItem>()
            .HasOne(p => p.List)
            .WithMany(b => b.Items)
            .HasForeignKey(p => p.ListId);
    }
    
    public DbSet<ToDoItem> ToDoItems { get; set; }
    public DbSet<ListToDo> ToDoLists { get; set; }
    
}