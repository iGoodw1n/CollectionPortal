using AutoMapper;
using CollectionDataLayer.DTOs;
using CollectionLogicLayer.Consts;
using CollectionLogicLayer.DTOs;

namespace CollectionLogicLayer.AutoMapperProfiles;

public class AppUserMapperProfiles : Profile
{
    public AppUserMapperProfiles()
    {
        CreateMap<AppUserWithRole, UserDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User.Id))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.IsBlocked, opt => opt.MapFrom(src => src.User.LockoutEnabled && src.User.LockoutEnd > DateTime.UtcNow))
            .ForMember(dest => dest.IsAdmin, opt => opt.MapFrom(src => src.Role.Name == Names.ADMIN));
    }
}
