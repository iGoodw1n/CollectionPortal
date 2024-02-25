using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Helpers;

namespace CollectionLogicLayer.Services;

public interface IItemService
{
    Task AddItem(ItemDto itemDto);

    Task<Item> GetItem(int id);

    Task<List<Item>> GetItemsByTag(int id);

    Task<QueryResultWithCount<Item>> GetItems(PaginationParams paginationParams);

    Task<PagedList<Item>> GetItemsByCollection(PaginationParams paginationParams, int collectionId);

    Task Update(ItemDto itemDto, int id, int userId);

    Task UpdateWithAdminRole(ItemDto itemDto, int id);

    Task Delete(int id, int userId);

    Task DeleteWithAdminRole(int id);
}
