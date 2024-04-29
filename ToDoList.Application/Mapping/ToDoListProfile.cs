using AutoMapper;
using ToDoList.Domain.Dtos.Request;
using ToDoList.Domain.Dtos.Response;
using ToDoList.Domain.Models;

namespace ToDoList.Application.Mapping;

public class ToDoListProfile : Profile
{
    public ToDoListProfile()
    {
        CreateMap<CreateToDoListRequest, ListToDo>();
        CreateMap<UpdateToDoListRequest, ListToDo>();
        CreateMap<ListToDo, ToDoListResponse>();
    }
}