using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Helpers;
using System.Linq.Expressions;

namespace CollectionDataLayer.Repositories;

public interface ICommentRepository
{
    void Add(Comment comment);

    void Delete(Comment comment);

    Task<Comment?> Get(int id);

    Task<Comment?> GetWithData(int id);

    Task<List<Comment>> GetAll();

    Task<QueryResultWithCount<Comment>> GetAllByItem(QueryParams queryParams, int itemId);

    Task<List<Comment>> GetAll(Expression<Func<Comment, bool>> filter);
}
