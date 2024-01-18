using CollectionLogicLayer.DTOs;

namespace CollectionLogicLayer.Services;

public interface ICollectionService
{
    Task CreateCollection(CollectionDto collectionDto);
}
