using CollectionDataLayer.Entities;
namespace CollectionDataLayer.Repositories;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllCategories();
}
