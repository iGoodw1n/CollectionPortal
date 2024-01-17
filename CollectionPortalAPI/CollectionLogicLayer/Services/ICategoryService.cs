using CollectionDataLayer.Entities;

namespace CollectionLogicLayer.Services;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategoriesAsync();
}
