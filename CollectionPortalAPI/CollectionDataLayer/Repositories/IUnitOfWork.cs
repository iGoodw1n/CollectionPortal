namespace CollectionDataLayer.Repositories;

public interface IUnitOfWork
{
    ICollectionRepository Collections { get; }

    ICategoryRepository Categories { get; }

    Task CompleteAsync();
}
