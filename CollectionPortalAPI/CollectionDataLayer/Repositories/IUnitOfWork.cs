namespace CollectionDataLayer.Repositories;

public interface IUnitOfWork
{
    ICollectionRepository Collections { get; }

    ICategoryRepository Categories { get; }

    IPhotoRepository Photos { get; }

    ITagRepository Tags { get; }

    Task CompleteAsync();
}
