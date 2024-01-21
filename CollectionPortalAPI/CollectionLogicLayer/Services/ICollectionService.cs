using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Helpers;

namespace CollectionLogicLayer.Services;

public interface ICollectionService
{
    Task AddCollection(CreateCollectionDto collectionDto, Photo? photo, int userId);

    Task<PagedList<CollectionDto>> GetAll(CollectionParams collectionParams, int? userId);

    Task<CollectionWithItemsDto> GetCollection(int id, PaginationParams paginationParams);
}
