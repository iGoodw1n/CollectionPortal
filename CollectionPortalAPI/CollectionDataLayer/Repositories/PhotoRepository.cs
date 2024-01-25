using CollectionDataLayer.Data;
using CollectionDataLayer.Entities;

namespace CollectionDataLayer.Repositories;

internal class PhotoRepository : IPhotoRepository
{
    private readonly AppDbContext _context;

    public PhotoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddPhoto(Photo photo)
    {
        _context.Photos.Add(photo);
    }

    public async Task<Photo?> GetPhoto(int photoId)
    {
        return await _context.Photos.FindAsync(photoId);
    }
}
