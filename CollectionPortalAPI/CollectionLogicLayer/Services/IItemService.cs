using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Helpers;

namespace CollectionLogicLayer.Services;

public interface IItemService
{
    Task AddItem(ItemDto itemDto);

    public Task<QueryResultWithCount<Item>> GetItems(PaginationParams paginationParams);
}
