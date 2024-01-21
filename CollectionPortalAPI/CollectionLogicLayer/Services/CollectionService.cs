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

    public CollectionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task AddCollection(CreateCollectionDto collectionDto, Photo? photo, int userId)
    {
        var collection = CreateCollection(collectionDto, photo, userId);
        _unitOfWork.Collections.Add(collection);
        await SaveToDb();
    }

    public async Task<PagedList<CollectionDto>> GetAll(CollectionParams collectionParams, int? userId)
    {
        var queryParams = ParamsHelper.ConvertPaginationParamsToQuery(collectionParams);
        var queryResult = collectionParams.CurrentUserOnly && userId is not null
            ? await GetAllCollectionsForUser(queryParams, userId.Value)
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
}
