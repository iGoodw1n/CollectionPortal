using CollectionDataLayer.Entities;

namespace CollectionDataLayer.Repositories;

public interface IPhotoRepository
{
    void AddPhoto(Photo photo);

    Task<Photo?> GetPhoto(int photoId);
}
