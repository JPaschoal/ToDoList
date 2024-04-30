using AutoMapper;
using ToDoList.Domain.Dtos.Request;
using ToDoList.Domain.Dtos.Response;
using ToDoList.Domain.Models;

namespace ToDoList.Application.Mapping;

public class ToDoItemProfile : Profile
{
    public ToDoItemProfile()
    {
        CreateMap<CreateItemRequest, ToDoItem>();
        CreateMap<ToDoItem, ToDoItemResponse>();
    }
}