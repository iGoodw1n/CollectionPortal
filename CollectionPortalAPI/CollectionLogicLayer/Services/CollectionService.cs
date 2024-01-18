using CollectionLogicLayer.DTOs;

namespace CollectionLogicLayer.Services;

internal class CollectionService : ICollectionService
{
    public Task CreateCollection(CollectionDto collectionDto)
    {
        return Task.CompletedTask;
    }
}
