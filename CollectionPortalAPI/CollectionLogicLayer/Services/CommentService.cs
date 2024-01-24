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

    public async Task Add(CommentDto commentDto, string userId)
    {
        var user = GetUserId(userId);
        var item = await GetItem(commentDto.ItemId);
        await AddComment(commentDto, user, item);
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

    public async Task<PagedList<CommentWithUser>> GetAllByItem(PaginationParams paginationParams, int id)
    {
        var queryParams = ParamsHelper.ConvertPaginationParamsToQuery(paginationParams);
        var comments = await _unitOfWork.Comments.GetAllByItem(queryParams, id);
        var commentsWithUserdata = _mapper.Map<QueryResultWithCount<CommentWithUser>>(comments);
        return ConvertToPagedList(commentsWithUserdata, paginationParams);
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

    private async Task<Item> GetItem(int itemId)
    {
        return await _unitOfWork.Items.Get(itemId) ?? throw new NotFoundException($"Item with id {itemId} not found");
    }

    private Task AddComment(CommentDto commentDto, int user, Item item)
    {
        var comment = _mapper.Map<Comment>(commentDto);
        comment.UserId = user;
        comment.Item = item;
        _unitOfWork.Comments.Add(comment);
        return SaveChanges();
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

    private PagedList<CommentWithUser> ConvertToPagedList(QueryResultWithCount<CommentWithUser> commentData, PaginationParams paginationParams)
    {
        return new PagedList<CommentWithUser>(commentData.Entities, commentData.TotalCount, paginationParams.PageNumber, paginationParams.PageSize);
    }
}
