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
    private readonly IToDoItemRepository _itemRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public ToDoService(IListToDoRepository listToDoRepository, IUnitOfWork unitOfWork, IMapper mapper, IToDoItemRepository itemRepository)
    {
        _listToDoRepository = listToDoRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _itemRepository = itemRepository;
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

    public async Task<ToDoListResponse?> Delete(Guid id)
    {
        var selectedList = await _listToDoRepository.GetById(id);
        if (selectedList == null)
            return null;
        
        var list = _mapper.Map<ListToDo>(selectedList);
        list.Status = 0;
        
        await _listToDoRepository.Update(list);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<ToDoListResponse>(list);
    }

    public async Task<ToDoItemResponse?> AddItem(CreateItemRequest task)
    {
        var item = _mapper.Map<ToDoItem>(task);
        await _itemRepository.Add(item);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<ToDoItemResponse>(item);
    }

    public async Task<ToDoItemResponse?> GetItems(Guid id)
    {
        var list = await _itemRepository.GetById(id);
        return _mapper.Map<ToDoItemResponse>(list);
    }
    
    public async Task<IEnumerable<ToDoItemResponse>> GetAllItemsByListId(Guid listId)
    {
        var items = await _itemRepository.GetByListId(listId);
        return _mapper.Map<IEnumerable<ToDoItemResponse>>(items);
    }

    public async Task<IEnumerable<ToDoItemResponse>> GetAllItems()
    {
        var items = await _itemRepository.All();
        return _mapper.Map<IEnumerable<ToDoItemResponse>>(items);
    }

    public async Task<ToDoItemResponse?> UpdateItem(Guid id, UpdateItemRequest itemToDoRequest)
    {
        var selectedItem = await _itemRepository.GetById(id);
        if (selectedItem == null)
            return null;
        
        var item = _mapper.Map<ToDoItem>(selectedItem);
        
        item.Title = itemToDoRequest.Title;
        item.UpdatedAt = DateTime.UtcNow;
        item.IsDone = itemToDoRequest.IsDone;
        if(itemToDoRequest.IsDone)
            item.CompletedAt = DateTime.UtcNow;
        
        await _itemRepository.Update(item);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<ToDoItemResponse>(item);
    }

    public async Task<ToDoItemResponse?> DeleteItem(Guid id)
    {
        var selectedItem = await _itemRepository.GetById(id);
        if (selectedItem == null)
            return null;
        
        var item = _mapper.Map<ToDoItem>(selectedItem);
        
        item.Status = 0;
        
        await _itemRepository.Update(item);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<ToDoItemResponse>(item);
    }
}