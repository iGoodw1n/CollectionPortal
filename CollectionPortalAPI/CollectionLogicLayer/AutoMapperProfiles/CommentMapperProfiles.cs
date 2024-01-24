using AutoMapper;
using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;

namespace CollectionLogicLayer.AutoMapperProfiles;

public class CommentMapperProfiles : Profile
{
    public CommentMapperProfiles()
    {
        CreateMap<CommentDto, Comment>();

        CreateMap<Comment, CommentWithUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

        CreateMap<QueryResultWithCount<Comment>, QueryResultWithCount<CommentWithUser>>();
    }
}
