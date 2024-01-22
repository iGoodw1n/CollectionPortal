using AutoMapper;
using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;

namespace CollectionLogicLayer.AutoMapperProfiles;

public class ItemMapperProfiles : Profile
{
    public ItemMapperProfiles()
    {
        CreateMap<ItemDto, Item>();
    }
}
