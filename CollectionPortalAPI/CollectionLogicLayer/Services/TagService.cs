using AutoMapper;
using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Exceptions;
using CollectionDataLayer.Repositories;
using CollectionLogicLayer.DTOs;

namespace CollectionLogicLayer.Services;

internal class TagService : ITagService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TagService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Tag> AddTag(Tag tag)
    {
        _unitOfWork.Tags.Add(tag);
        await _unitOfWork.CompleteAsync();
        return tag;
    }

    public async Task<TagDto> Get(int id)
    {
        var tag = await _unitOfWork.Tags.Get(id) ?? throw new NotFoundException($"Tag with id {id} not found");
        return _mapper.Map<TagDto>(tag);
    }

    public async Task<List<TagDto>> GetAll()
    {
        var tags = await _unitOfWork.Tags.GetAll();
        return _mapper.Map<List<TagDto>>(tags);
    }

    public async Task<List<TagDtoWithCount>> GetAllTagsWithCount()
    {
        var tagsWithCount = await _unitOfWork.Tags.GetTagsWithItems();
        return _mapper.Map<List<TagDtoWithCount>>(tagsWithCount);
    }
}
