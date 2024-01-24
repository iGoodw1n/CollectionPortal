using CollectionDataLayer.Data;
using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace CollectionDataLayer.Repositories;

internal class ItemRepository : IItemRepository
{
    private readonly AppDbContext _context;

    public ItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Item?> Get(int id)
    {
        return await _context.Items.Include(i => i.Collection).FirstOrDefaultAsync(i => i.Id == id);
    }

    public Task<QueryResultWithCount<Item>> GetAll(QueryParams queryParams)
    {
        var query = _context.Items
            .Include(i => i.Collection)
                .ThenInclude(c => c.User)
            .OrderBy($"{queryParams.OrderBy} {queryParams.OrderType}");
        return GetQuery(query, queryParams);
    }

    private async Task<QueryResultWithCount<Item>> GetQuery(IQueryable<Item> query, QueryParams queryParams)
    {
        var count = await query.CountAsync();
        var items = await query.Skip(queryParams.Skip).Take(queryParams.Take).ToListAsync();
        return new QueryResultWithCount<Item> { TotalCount = count, Entities = items };
    }
}
