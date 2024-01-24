using AutoMapper;
using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Exceptions;
using CollectionDataLayer.Repositories;
using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Helpers;

namespace CollectionLogicLayer.Services;

internal class ItemService : IItemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ItemService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task AddItem(ItemDto itemDto)
    {
        var collection = await GetCollection(itemDto);
        await AddItemToCollection(itemDto, collection);
        await SaveChanges();
    }

    public Task<QueryResultWithCount<Item>> GetItems(PaginationParams paginationParams)
    {
        var queryParams = ParamsHelper.ConvertPaginationParamsToQuery(paginationParams);
        return _unitOfWork.Items.GetAll(queryParams);
    }

    public async Task<Item> GetItem(int id)
    {
        var item = await _unitOfWork.Items.Get(id) ?? throw new NotFoundException("Item not found");
        return item;
    }

    private async Task<Collection> GetCollection(ItemDto itemDto)
    {
        return await _unitOfWork.Collections.Get(itemDto.CollectionId)
                    ?? throw new NotFoundException($"Collection with id {itemDto.CollectionId} not found");
    }

    private async Task AddItemToCollection(ItemDto itemDto, Collection collection)
    {
        Item item = await CreateItem(itemDto);
        collection.Items.Add(item);
    }

    private async Task<Item> CreateItem(ItemDto itemDto)
    {
        var item = _mapper.Map<Item>(itemDto);
        var tags = await GetTags(itemDto.TagIds);
        item.Tags.AddRange(tags);
        item.CreationDate = DateTime.UtcNow;
        return item;
    }

    private async Task<List<Tag>> GetTags(List<int> tagIds)
    {
        var tags = await _unitOfWork.Tags.GetAll(t => tagIds.Contains(t.Id));
        return tags.Count == tagIds.Count ? tags : throw new NotFoundException("Not all tags exist");
    }

    private async Task SaveChanges()
    {
        await _unitOfWork.CompleteAsync();
    }
}
