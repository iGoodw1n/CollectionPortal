using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Helpers;
using System.Linq.Expressions;

namespace CollectionDataLayer.Repositories;

public interface IItemRepository
{
    Task<Item?> Get(int id);

    Task<QueryResultWithCount<Item>> GetAll(QueryParams queryParams);

    Task<List<Item>> GetAll(Expression<Func<Item, bool>> filter);

    Task<QueryResultWithCount<Item>> GetAllByCollection(QueryParams queryParams, int collectionId);

    void Delete(Item item);

    void Update(Item currentm, Item updated);
}
