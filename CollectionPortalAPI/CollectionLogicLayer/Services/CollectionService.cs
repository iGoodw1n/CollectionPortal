using AutoMapper;
using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;

namespace CollectionLogicLayer.Services;

internal class CollectionService : ICollectionService
{
    private readonly IMapper _mapper;

    public CollectionService(IMapper mapper)
    {
        _mapper = mapper;
    }
    public Task CreateCollection(CollectionDto collectionDto)
    {
        var collection = _mapper.Map<Collection>(collectionDto);
        Console.WriteLine(collectionDto);
        return Task.CompletedTask;
    }

}
