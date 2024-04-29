using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Services;
using ToDoList.Data;
using ToDoList.Data.Repositorys;
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
            options.UseNpgsql(connectionString));
        // Repositories
        services.AddScoped<IListToDoRepository, ListToDoRepository>();
        // Services
        services.AddScoped<IToDoService, ToDoService>();
    }
}