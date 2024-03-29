﻿using CollectionDataLayer.Data;
using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace CollectionDataLayer.Repositories;

internal class ItemRepository : IItemRepository
{
    private readonly AppDbContext _context;

    public ItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Delete(Item item)
    {
        _context.Items.Remove(item);
    }

    public async Task<Item?> Get(int id)
    {
        return await _context.Items.Include(i => i.Collection).Include(i => i.Tags).FirstOrDefaultAsync(i => i.Id == id);
    }

    public Task<QueryResultWithCount<Item>> GetAll(QueryParams queryParams)
    {
        var query = _context.Items
            .Include(i => i.Collection)
                .ThenInclude(c => c.User)
            .OrderBy($"{queryParams.OrderBy} {queryParams.OrderType}");
        return GetQuery(query, queryParams);
    }

    public Task<List<Item>> GetAll(Expression<Func<Item, bool>> filter)
    {
        return _context.Items.Where(filter).ToListAsync();
    }

    public Task<QueryResultWithCount<Item>> GetAllByCollection(QueryParams queryParams, int collectionId)
    {
        Console.WriteLine("Collection Id: " + collectionId);
        var query = _context.Items
            .Where(i => i.CollectionId == collectionId)
            .OrderBy($"{queryParams.OrderBy} {queryParams.OrderType}");
        return GetQuery(query, queryParams);
    }

    public void Update(Item current, Item updated)
    {
        _context.Entry(current).CurrentValues.SetValues(updated);
    }

    private async Task<QueryResultWithCount<Item>> GetQuery(IQueryable<Item> query, QueryParams queryParams)
    {
        Console.WriteLine("Items For Collection");
        var count = await query.CountAsync();
        var items = await query.Skip(queryParams.Skip).Take(queryParams.Take).ToListAsync();
        Console.WriteLine(items.Count);
        return new QueryResultWithCount<Item> { TotalCount = count, Entities = items };
    }
}
