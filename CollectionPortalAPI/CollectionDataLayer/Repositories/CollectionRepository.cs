using CollectionDataLayer.Data;
using CollectionDataLayer.Entities;
using Microsoft.EntityFrameworkCore;

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
}
