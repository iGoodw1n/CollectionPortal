using CollectionDataLayer.Data;
using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CollectionDataLayer.Repositories;

internal class CollectionRepository : ICollectionRepository
{
    private readonly AppDbContext _context;

    public CollectionRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Collection collection)
    {
        _context.Collections.Add(collection);
    }

    public async Task<Collection?> Get(int id)
    {
        return await  _context.Collections.FindAsync(id);
    }

    public Task<QueryResultWithCount<Collection>> GetAll(QueryParams queryParams)
    {
        IQueryable<Collection> query = CreateQuery();
        return GetQuery(query, queryParams);
    }

    public Task<QueryResultWithCount<Collection>> GetAll(QueryParams queryParams, Expression<Func<Collection, bool>> filter)
    {
        IQueryable<Collection> query = CreateQuery();
        return GetQuery(query.Where(filter), queryParams);
    }

    public Task<QueryResultForCollectionWithCount> GetCollectionWithItems(int id, QueryParams queryParams)
    {
        var query = CreateQuery().Where(c => c.Id == id);
        return GetQueryWithItems(query, queryParams, id);
    }

    private IQueryable<Collection> CreateQuery()
    {
        return _context.Collections
                    .Include(c => c.Photo)
                    .Include(c => c.Category)
                    .AsQueryable();
    }

    private async Task<QueryResultWithCount<Collection>> GetQuery(IQueryable<Collection> query, QueryParams queryParams)
    {
        var count = await query.CountAsync();
        var collections = await query.OrderBy(c => c.CreationDate).Skip(queryParams.Skip).Take(queryParams.Take).ToListAsync();
        return new QueryResultWithCount<Collection> { TotalCount = count, Entities = collections };
    }

    private async Task<QueryResultForCollectionWithCount> GetQueryWithItems(IQueryable<Collection> query, QueryParams queryParams, int collectionId)
    {
        var count = await _context.Items.Where(i => i.CollectionId == collectionId).CountAsync();
        var collection = await query
            .Include(c => c.Items.OrderBy(i => i.CreationDate).Skip(queryParams.Skip).Take(queryParams.Take))
            .ThenInclude(i => i.Tags)
            .FirstOrDefaultAsync();
        return new QueryResultForCollectionWithCount { TotalCount = count, Collection = collection };
    }

}
