using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ToDoList.Application.Services;
using ToDoList.Data;
using ToDoList.Data.Repository;
using ToDoList.Domain.Interfaces.Repository;
using ToDoList.Domain.Interfaces.Services;
namespace ToDoList.IoC;

public class DependecyContainer
{
    public static void RegisterServices(IServiceCollection services, string? connectionString)
    {
        // Registering services
        // Context
        services.AddDbContext<ToDoContext>(options =>
            options.UseLazyLoadingProxies().UseNpgsql(connectionString));
        // Repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IListToDoRepository, ListToDoRepository>();
        services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
        // Services
        services.AddScoped<IToDoListService, ToDoListService>();
        services.AddScoped<IToDoItemService, ToDoItemService>();
    }
}