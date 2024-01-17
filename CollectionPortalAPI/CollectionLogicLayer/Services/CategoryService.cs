using CollectionDataLayer.Entities;
using CollectionDataLayer.Repositories;

namespace CollectionLogicLayer.Services;

internal class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<List<Category>> GetAllCategoriesAsync()
    {
        return _unitOfWork.Categories.GetAllCategories();
    }
}
