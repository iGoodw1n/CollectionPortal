using Algolia.Search.Clients;
using AutoMapper;
using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Exceptions;
using CollectionDataLayer.Repositories;
using CollectionLogicLayer.Consts;
using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Helpers;

namespace CollectionLogicLayer.Services;

internal class ItemService : IItemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ISearchClient _searchClient;

    public ItemService(IUnitOfWork unitOfWork, IMapper mapper, ISearchClient searchClient)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _searchClient = searchClient;
    }
    public async Task AddItem(ItemDto itemDto)
    {
        var collection = await GetCollection(itemDto);
        var item = await AddItemToCollection(itemDto, collection);
        var searchIndex = _searchClient.InitIndex(Names.INDEX);
        await searchIndex.SaveObjectAsync(item);
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

    public async Task Update(ItemDto itemDto, int id, int userId)
    {
        var item = await GetItem(id);
        if (item.Collection.UserId != userId)
        {
            throw new ForbiddenAccessException();
        }
        await UpdateItem(itemDto, item);
    }

    public async Task UpdateWithAdminRole(ItemDto itemDto, int id)
    {
        var item = await GetItem(id);
        await UpdateItem(itemDto, item);
    }

    private async Task UpdateItem(ItemDto itemDto, Item item)
    {
        var updatedItem = _mapper.Map<Item>(itemDto);
        _unitOfWork.Items.Update(item, updatedItem);
        await SaveChanges();
    }

    public async Task Delete(int id, int userId)
    {
        var item = await GetItem(id);
        if (item.Collection.UserId != userId)
        {
            throw new ForbiddenAccessException();
        }
        await DeleteItem(item);
    }

    public async Task DeleteWithAdminRole(int id)
    {
        var item = await GetItem(id);
        await DeleteItem(item);
    }

    private async Task DeleteItem(Item item)
    {
        _unitOfWork.Items.Delete(item);
        await SaveChanges();
    }

    private async Task<Collection> GetCollection(ItemDto itemDto)
    {
        return await _unitOfWork.Collections.Get(itemDto.CollectionId)
                    ?? throw new NotFoundException($"Collection with id {itemDto.CollectionId} not found");
    }

    private async Task<Item> AddItemToCollection(ItemDto itemDto, Collection collection)
    {
        Item item = await CreateItem(itemDto);
        collection.Items.Add(item);
        await SaveChanges();
        return item;
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
