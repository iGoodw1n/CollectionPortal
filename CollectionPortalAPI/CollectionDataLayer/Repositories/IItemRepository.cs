using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Helpers;

namespace CollectionDataLayer.Repositories;

public interface IItemRepository
{
    public Task<QueryResultWithCount<Item>> GetAll(QueryParams queryParams);
}
