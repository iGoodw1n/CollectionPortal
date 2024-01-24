using CollectionDataLayer.Entities;
using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Helpers;

namespace CollectionLogicLayer.Services;

public interface ICommentService
{
    Task Add(CommentDto commentDto, string userId);

    Task Delete(int id, string userId);

    Task DeleteWithAdminRole(int id);

    Task<PagedList<CommentWithUser>> GetAllByItem(PaginationParams paginationParams, int id);
}
