using AutoMapper;
using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;
namespace CollectionLogicLayer.AutoMapperProfiles;

public class CollectionMapperProfiles : Profile
{
    public CollectionMapperProfiles()
    {
        CreateMap<CollectionDto, Collection>();
    }
}
