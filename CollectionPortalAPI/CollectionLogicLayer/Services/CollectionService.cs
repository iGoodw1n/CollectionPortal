using AutoMapper;
using CloudinaryDotNet.Actions;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Repositories;
using CollectionLogicLayer.DTOs;

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
    public async Task AddCollection(CollectionDto collectionDto, Photo? photo, int userId)
    {
        var collection = CreateCollection(collectionDto, photo, userId);
        _unitOfWork.Collections.Add(collection);
        await SaveToDb();
    }

    private Collection CreateCollection(CollectionDto collectionDto, Photo? photo, int userId)
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
}
