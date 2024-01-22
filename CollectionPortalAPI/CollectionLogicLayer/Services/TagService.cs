using CollectionDataLayer.Entities;
using CollectionDataLayer.Exceptions;
using CollectionDataLayer.Repositories;

namespace CollectionLogicLayer.Services;

internal class TagService : ITagService
{
    private readonly IUnitOfWork _unitOfWork;

    public TagService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Tag> AddTag(Tag tag)
    {
        _unitOfWork.Tags.Add(tag);
        await _unitOfWork.CompleteAsync();
        return tag;
    }

    public async Task<Tag> Get(int id)
    {
        return await _unitOfWork.Tags.Get(id) ?? throw new NotFoundException($"Tag with id {id} not found");
    }

    public Task<List<Tag>> GetAll()
    {
        return _unitOfWork.Tags.GetAll();
    }
}
