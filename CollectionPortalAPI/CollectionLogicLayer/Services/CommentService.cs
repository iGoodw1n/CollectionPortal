using AutoMapper;
using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Exceptions;
using CollectionDataLayer.Repositories;
using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Helpers;

namespace CollectionLogicLayer.Services;

internal class CommentService : ICommentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task Add(CommentDto commentDto)
    {
        var comment = _mapper.Map<Comment>(commentDto);
        _unitOfWork.Comments.Add(comment);
        await SaveChanges();
    }

    public async Task Delete(int id, string userId)
    {
        var comment = await _unitOfWork.Comments.GetWithData(id) ?? throw new NotFoundException($"Comment with id {id} not found");
        CheckCommentData(comment, userId);
        _unitOfWork.Comments.Delete(comment);
        await SaveChanges();
    }


    public async Task DeleteWithAdminRole(int id)
    {
        var comment = await _unitOfWork.Comments.Get(id) ?? throw new NotFoundException($"Comment with id {id} not found");
        _unitOfWork.Comments.Delete(comment);
        await SaveChanges();
    }

    public async Task<PagedList<Comment>> GetAllByItem(PaginationParams paginationParams, int id)
    {
        var queryParams = ParamsHelper.ConvertPaginationParamsToQuery(paginationParams);
        var comments = await _unitOfWork.Comments.GetAllByItem(queryParams, id);
        return ConvertToPagedList(comments, paginationParams);
    }

    private void CheckCommentData(Comment comment, string userId)
    {
        int id = GetUserId(userId);
        if (comment.Item.Collection.UserId != id)
        {
            throw new ForbiddenAccessException("User does not have rights");
        }
    }

    private static int GetUserId(string userId)
    {
        if (!int.TryParse(userId, out var id))
        {
            throw new ArgumentException(nameof(userId));
        }

        return id;
    }

    private async Task CheckUserRights(int itemId, int id)
    {
        var item = await _unitOfWork.Items.Get(itemId) ?? throw new NotFoundException($"Item with id {itemId} not found");
        if (item.Collection.UserId != id)
        {
            throw new ForbiddenAccessException("User does not haave rights for this operation");
        }
    }

    private Task SaveChanges()
    {
        return _unitOfWork.CompleteAsync();
    }

    private PagedList<Comment> ConvertToPagedList(QueryResultWithCount<Comment> commentData, PaginationParams paginationParams)
    {
        return new PagedList<Comment>(commentData.Entities, commentData.TotalCount, paginationParams.PageNumber, paginationParams.PageSize);
    }
}
