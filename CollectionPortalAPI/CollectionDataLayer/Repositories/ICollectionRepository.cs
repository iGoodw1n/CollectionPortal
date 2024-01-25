using CollectionDataLayer.Helpers;
using CollectionDataLayer.Entities;
using System.Linq.Expressions;
using CollectionDataLayer.DTOs;

namespace CollectionDataLayer.Repositories;

public interface ICollectionRepository
{
    void Add(Collection collection);

    Task<Collection?> Get(int id);

    Task<QueryResultWithCount<Collection>> GetAll(QueryParams queryParams);

    Task<QueryResultWithCount<Collection>> GetAll(QueryParams queryParams, Expression<Func<Collection, bool>> filter);

    Task<QueryResultForCollectionWithCount> GetCollectionWithItems(int id, QueryParams queryParams);

    void Delete(Collection collection);
}
