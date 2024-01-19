using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;

namespace CollectionLogicLayer.Services;

public interface ICollectionService
{
    Task AddCollection(CollectionDto collectionDto, Photo? photo, int userId);
}
