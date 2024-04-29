using ToDoList.IoC;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

DependecyContainer.RegisterServices(builder.Services, configuration["ConnectionStrings:DefaultConnection"]);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();