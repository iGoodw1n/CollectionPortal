namespace CollectionDataLayer.Repositories;

public interface IUnitOfWork
{
    ICollectionRepository Collections { get; }

    ICategoryRepository Categories { get; }

    IPhotoRepository Photos { get; }

    Task CompleteAsync();
}
