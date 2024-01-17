using CollectionDataLayer.Data;
using CollectionDataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollectionDataLayer.Repositories;

internal class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllCategories()
    {
        return await _context.Categories.ToListAsync();
    }
}
