using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Helpers;

namespace CollectionDataLayer.Repositories;

public interface IItemRepository
{
    Task<Item?> Get(int id);

    Task<QueryResultWithCount<Item>> GetAll(QueryParams queryParams);
}
