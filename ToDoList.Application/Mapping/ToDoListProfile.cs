using AutoMapper;
using ToDoList.Domain.Dtos.Request;
using ToDoList.Domain.Dtos.Response;
using ToDoList.Domain.Models;

namespace ToDoList.Data.Mapping;

public class ToDoListProfile : Profile
{
    public ToDoListProfile()
    {
        CreateMap<CreateToDoListRequest, ListToDo>()
            .ForMember(dest => dest.Title, 
                opt => opt.MapFrom(x => x.Title));
        CreateMap<ListToDo, ToDoListResponse>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(x => x.Id))
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(x => x.Title))
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(x => x.Status))
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(x => x.CreatedAt))
            .ForMember(dest => dest.UpdatedAt,
                opt => opt.MapFrom(x => x.UpdatedAt));
    }
}