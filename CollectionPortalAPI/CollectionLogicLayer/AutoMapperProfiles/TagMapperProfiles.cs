using AutoMapper;
using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;

namespace CollectionLogicLayer.AutoMapperProfiles;

public class TagMApperProfiles : Profile
{
    public TagMApperProfiles()
    {
        CreateMap<Tag, TagDto>();

        CreateMap<TagWithCount, TagDtoWithCount>();
    }
}
