using AutoMapper;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Repositories;
using CollectionLogicLayer.DTOs;
using CollectionDataLayer.Helpers;
using CollectionLogicLayer.Helpers;
using CollectionDataLayer.DTOs;
using CollectionDataLayer.Exceptions;

namespace CollectionLogicLayer.Services;

internal class CollectionService : ICollectionService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPhotoService _photoService;

    public CollectionService(IUnitOfWork unitOfWork, IPhotoService photoService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _photoService = photoService;
        _mapper = mapper;
    }
    public async Task AddCollection(CreateCollectionDto collectionDto, Photo? photo, int userId)
    {
        var collection = CreateCollection(collectionDto, photo, userId);
        _unitOfWork.Collections.Add(collection);
        await SaveToDb();
    }

    public async Task<PagedList<CollectionDto>> GetAll(CollectionParams collectionParams)
    {
        var queryParams = ParamsHelper.ConvertPaginationParamsToQuery(collectionParams);
        var queryResult = collectionParams.UserId is not null
            ? await GetAllCollectionsForUser(queryParams, collectionParams.UserId.Value)
            : await GetAllCollections(queryParams);
        return MapData(queryResult, collectionParams);
    }

    public async Task<CollectionWithItemsDto> GetCollection(int id, PaginationParams paginationParams)
    {
        var queryParams = ParamsHelper.ConvertPaginationParamsToQuery(paginationParams);
        var collectionData = await _unitOfWork.Collections.GetCollectionWithItems(id, queryParams);
        if (collectionData.Collection is null)
        {
            throw new NotFoundException($"Collection with id {id} not found");
        }
        return MapData(collectionData, paginationParams);
    }

    public async Task<Collection> GetCollection(int id)
    {
        var collection = await _unitOfWork.Collections.Get(id) ?? throw new NotFoundException($"Collection with id {id} not exist");
        return collection;
    }

    public async Task UpdateCollection(int collectionId, UpdateCollectionDto collectionDto, int userId)
    {
        
        var collection = await _unitOfWork.Collections.Get(collectionId) ?? throw new NotFoundException($"Collection with id {collectionId} not exist");
        CheckUser(collection, userId);
        await UpdateCollection(collection, collectionDto);
    }

    public async Task UpdateCollectionAsAdmin(int collectionId, UpdateCollectionDto collectionDto)
    {
        var collection = await _unitOfWork.Collections.Get(collectionId) ?? throw new NotFoundException($"Collection with id {collectionId} not exist");
        await UpdateCollection(collection, collectionDto);
    }

    public async Task Delete(int id, int userId)
    {
        var collection = await _unitOfWork.Collections.Get(id) ?? throw new NotFoundException();
        if (collection.UserId != userId)
        {
            throw new ForbiddenAccessException();
        }
        await DeleteCollection(collection);
    }

    public async Task DeleteWithAdminRole(int id)
    {
        var collection = await _unitOfWork.Collections.Get(id) ?? throw new NotFoundException();
        await DeleteCollection(collection);
    }

    private async Task DeleteCollection(Collection collection)
    {
        await DeletePhoto(collection);
        _unitOfWork.Collections.Delete(collection);
        await SaveToDb();
    }

    private async Task DeletePhoto(Collection collection)
    {
        if (collection.PhotoId is not null)
        {
            var photo = await _unitOfWork.Photos.GetPhoto(collection.PhotoId.Value) ?? throw new NotFoundException("Photo");
            await _photoService.DeletePhotoAsync(photo.PublicId);
        }
    }

    private Collection CreateCollection(CreateCollectionDto collectionDto, Photo? photo, int userId)
    {
        var collection = _mapper.Map<Collection>(collectionDto);
        collection.UserId = userId;
        collection.Photo = photo;
        return collection;
    }

    private Task SaveToDb()
    {
        return _unitOfWork.CompleteAsync();
    }

    private Task<QueryResultWithCount<Collection>> GetAllCollectionsForUser(QueryParams queryParams, int userId)
    {
        return _unitOfWork.Collections.GetAll(queryParams, c => c.UserId == userId);
    }

    private Task<QueryResultWithCount<Collection>> GetAllCollections(QueryParams queryParams)
    {
        return  _unitOfWork.Collections.GetAll(queryParams);
    }

    private PagedList<CollectionDto> MapData(QueryResultWithCount<Collection> collectionData, CollectionParams collectionParams)
    {
        var items = _mapper.Map<List<Collection>, List<CollectionDto>>(collectionData.Entities);
        return new PagedList<CollectionDto>(items, collectionData.TotalCount, collectionParams.PageNumber, collectionParams.PageSize);
    }

    private CollectionWithItemsDto MapData(QueryResultForCollectionWithCount collectionData, PaginationParams paginationParams)
    {
        var collection = _mapper.Map<CollectionWithItemsDto>(collectionData.Collection);
        if (collectionData.Collection!.Items.Count != 0)
        {
            collection.PaginatedItems = new (collectionData.Collection!.Items, collectionData.TotalCount, paginationParams.PageNumber, paginationParams.PageSize);
        }
        return collection;
    }

    private void CheckUser(Collection collection, int? userId)
    {
        if (userId == null)
        {
            throw new ArgumentNullException(nameof(userId));
        }
        if (collection.UserId != userId)
        {
            throw new ForbiddenAccessException();
        }
    }

    private Task UpdateCollection(Collection collection, UpdateCollectionDto collectionDto)
    {
        collection.Name = collectionDto.Name;
        collection.Description = collectionDto.Description;
        collection.CategoryId = collectionDto.CategoryId;
        return SaveToDb();
    }
}
