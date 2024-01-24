using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Helpers;

namespace CollectionLogicLayer.Services;

public interface ICommentService
{
    Task Add(CommentDto commentDto);

    Task Delete(int id, string userId);

    Task DeleteWithAdminRole(int id);

    Task<PagedList<Comment>> GetAllByItem(PaginationParams paginationParams, int id);
}
