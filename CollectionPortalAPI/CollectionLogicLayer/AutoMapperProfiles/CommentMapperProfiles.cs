using AutoMapper;
using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;

namespace CollectionLogicLayer.AutoMapperProfiles;

public class CommentMapperProfiles : Profile
{
    public CommentMapperProfiles()
    {
        CreateMap<CommentDto, Comment>();
    }
}
