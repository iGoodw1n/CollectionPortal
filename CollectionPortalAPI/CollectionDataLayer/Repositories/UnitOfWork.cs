using CollectionDataLayer.Data;

namespace CollectionDataLayer.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(
        AppDbContext context,
        ICategoryRepository categoryRepository,
        ICollectionRepository collectionRepository,
        IPhotoRepository photoRepository
        )
    {
        _context = context;
        Categories = categoryRepository;
        Collections = collectionRepository;
        Photos = photoRepository;
    }

    public ICategoryRepository Categories { get; }

    public ICollectionRepository Collections { get; }

    public IPhotoRepository Photos { get; }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}
