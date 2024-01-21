using AutoMapper;
using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;
namespace CollectionLogicLayer.AutoMapperProfiles;

public class CollectionMapperProfiles : Profile
{
    public CollectionMapperProfiles()
    {
        CreateMap<CreateCollectionDto, Collection>();
        CreateMap<Collection, CollectionDto>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Photo != null ? src.Photo.Url : null));
        CreateMap<Collection, CollectionWithItemsDto>()
            .IncludeBase<Collection, CollectionDto>();
    }
}
