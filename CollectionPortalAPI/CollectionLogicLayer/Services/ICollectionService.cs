using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Helpers;

namespace CollectionLogicLayer.Services;

public interface ICollectionService
{
    Task AddCollection(CreateCollectionDto collectionDto, Photo? photo, int userId);

    Task UpdateCollection(int collectionId, UpdateCollectionDto collectionDto, int userId);

    Task UpdateCollectionAsAdmin(int collectionId, UpdateCollectionDto collectionDto);

    Task<PagedList<CollectionDto>> GetAll(CollectionParams collectionParams);

    Task<CollectionWithItemsDto> GetCollection(int id, PaginationParams paginationParams);

    Task<Collection> GetCollection(int id);

    Task Delete(int id, int userId);

    Task DeleteWithAdminRole(int id);
}
