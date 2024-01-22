using CollectionDataLayer.Entities;

namespace CollectionLogicLayer.Services;

public interface ITagService
{
    Task<Tag> Get(int id);
    Task<List<Tag>> GetAll();

    Task<Tag> AddTag(Tag tag);
}
