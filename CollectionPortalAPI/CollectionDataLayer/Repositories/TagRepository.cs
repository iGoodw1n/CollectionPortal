using CollectionDataLayer.Data;
using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CollectionDataLayer.Repositories;

internal class TagRepository : ITagRepository
{
    private readonly AppDbContext _context;

    public TagRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Add(Tag tag)
    {
        _context.Tags.Add(tag);  
    }

    public async Task<Tag?> Get(int id)
    {
        return await _context.Tags.FindAsync(id);
    }

    public async Task<List<Tag>> GetAll()
    {
        return await _context.Tags.ToListAsync();
    }

    public async Task<List<Tag>> GetAll(Expression<Func<Tag, bool>> filter)
    {
        return await _context.Tags.Where(filter).ToListAsync();
    }

    public Task<List<TagWithCount>> GetTagsWithItems()
    {
        return _context.Tags
            .Include(t => t.Items)
            .Select(t => new TagWithCount() { Tag = t, Count = t.Items.Count })
            .ToListAsync();
    }
}
