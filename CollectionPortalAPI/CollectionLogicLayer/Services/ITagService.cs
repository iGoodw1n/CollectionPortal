using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;

namespace CollectionLogicLayer.Services;

public interface ITagService
{
    Task<TagDto> Get(int id);

    Task<List<TagDtoWithCount>> GetAllTagsWithCount();

    Task<List<TagDto>> GetAll();

    Task<Tag> AddTag(Tag tag);
}
