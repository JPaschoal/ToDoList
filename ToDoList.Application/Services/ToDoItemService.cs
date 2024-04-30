using AutoMapper;
using ToDoList.Domain.Dtos.Request;
using ToDoList.Domain.Dtos.Response;
using ToDoList.Domain.Interfaces.Repository;
using ToDoList.Domain.Interfaces.Services;
using ToDoList.Domain.Models;

namespace ToDoList.Application.Services;

public class ToDoItemService : IToDoItemService
{
    private readonly IToDoItemService _toDoItemService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToDoItemRepository _itemRepository;
    
    public ToDoItemService(IToDoItemService toDoItemService, IMapper mapper, IUnitOfWork unitOfWork, IToDoItemRepository itemRepository)
    {
        _toDoItemService = toDoItemService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _itemRepository = itemRepository;
    }
    
    public async Task<ToDoItemResponse?> AddItem(CreateItemRequest task)
    {
        var item = _mapper.Map<ToDoItem>(task);
        await _itemRepository.Add(item);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<ToDoItemResponse>(item);
    }

    public async Task<ToDoItemResponse?> GetItemById(Guid id)
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