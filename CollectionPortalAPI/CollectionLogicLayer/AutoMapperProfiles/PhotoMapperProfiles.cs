using AutoMapper;
using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;

namespace CollectionLogicLayer.AutoMapperProfiles;

public class PhotoMapperProfiles : Profile
{
    public PhotoMapperProfiles()
    {
        CreateMap<Photo, PhotoDto>();
    }
}
