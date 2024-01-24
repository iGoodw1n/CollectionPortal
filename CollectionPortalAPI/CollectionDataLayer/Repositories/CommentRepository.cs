using CollectionDataLayer.Data;
using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace CollectionDataLayer.Repositories;

internal class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;

    public CommentRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Add(Comment comment)
    {
        _context.Comments.Add(comment);
    }

    public void Delete(Comment comment)
    {
        _context.Comments.Remove(comment);
    }

    public async Task<Comment?> Get(int id)
    {
        return await _context.Comments.FindAsync(id);
    }

    public async Task<Comment?> GetWithData(int id)
    {
        return await _context.Comments.Include(i => i.Item).ThenInclude(i => i.Collection).FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<QueryResultWithCount<Comment>> GetAllByItem(QueryParams queryParams, int itemId)
    {
        var query = _context.Comments
            .Where(c => c.ItemId == itemId)
            .OrderBy($"{queryParams.OrderBy} {queryParams.OrderType}");
        return GetQuery(query, queryParams);
    }

    public Task<List<Comment>> GetAll()
    {
        return _context.Comments.ToListAsync();
    }

    public Task<List<Comment>> GetAll(Expression<Func<Comment, bool>> filter)
    {
        return _context.Comments.Where(filter).ToListAsync();
    }

    private async Task<QueryResultWithCount<Comment>> GetQuery(IQueryable<Comment> query, QueryParams queryParams)
    {
        var count = await query.CountAsync();
        var items = await query.Skip(queryParams.Skip).Take(queryParams.Take).ToListAsync();
        return new QueryResultWithCount<Comment> { TotalCount = count, Entities = items };
    }
}
