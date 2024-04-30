using AutoMapper;
using ToDoList.Domain.Dtos.Request;
using ToDoList.Domain.Dtos.Response;
using ToDoList.Domain.Interfaces.Repository;
using ToDoList.Domain.Interfaces.Services;
using ToDoList.Domain.Models;

namespace ToDoList.Application.Services;

public class ToDoService : IToDoService
{
    private readonly IListToDoRepository _listToDoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public ToDoService(IListToDoRepository listToDoRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _listToDoRepository = listToDoRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ToDoListResponse>> GetAllLists()
    {
        var lists = await _listToDoRepository.All();
        return _mapper.Map<IEnumerable<ToDoListResponse>>(lists);
    }

    public async Task<ToDoListResponse> CreateList(CreateToDoListRequest listToDo)
    {
        var list = _mapper.Map<ListToDo>(listToDo);
        await _listToDoRepository.Add(list);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<ToDoListResponse>(list);
    }

    public async Task<ToDoListResponse> GetById(Guid id)
    {
        var list = await _listToDoRepository.GetById(id);
        return _mapper.Map<ToDoListResponse>(list);
    }

    public async Task<ToDoListResponse?> UpdateList(Guid id, UpdateToDoListRequest listToDo)
    {
        var selectedList = await _listToDoRepository.GetById(id);
        if (selectedList == null)
            return null;
        
        var list = _mapper.Map<ListToDo>(selectedList);
        
        list.Title = listToDo.Title!;
        list.UpdatedAt = DateTime.UtcNow;
            
        await _listToDoRepository.Update(list);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<ToDoListResponse>(list);
    }
}