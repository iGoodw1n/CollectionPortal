using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollectionPortalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ICollectionService _collectionService;
        private readonly IPhotoService _photoService;

        public CollectionController(ICategoryService categoryService, ICollectionService collectionService, IPhotoService photoService)
        {
            _categoryService = categoryService;
            _collectionService = collectionService;
            _photoService = photoService;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection(CollectionDto collectionDto)
        {
            await _collectionService.CreateCollection(collectionDto);
            return Created();
        }
    }
}
