using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using System.Linq.Expressions;

namespace CollectionDataLayer.Repositories;

public interface ITagRepository
{
    void Add(Tag collection);

    Task<Tag?> Get(int id);

    Task<List<TagWithCount>> GetTagsWithItems();

    Task<List<Tag>> GetAll();

    Task<List<Tag>> GetAll(Expression<Func<Tag, bool>> filter);
}
