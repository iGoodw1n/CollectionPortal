using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Helpers;

namespace CollectionDataLayer.Repositories;

public interface IItemRepository
{
    Task<Item?> Get(int id);

    Task<QueryResultWithCount<Item>> GetAll(QueryParams queryParams);

    Task<QueryResultWithCount<Item>> GetAllByCollection(QueryParams queryParams, int collectionId);

    void Delete(Item item);

    void Update(Item currentm, Item updated);
}
