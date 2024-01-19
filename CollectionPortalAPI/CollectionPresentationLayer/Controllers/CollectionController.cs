using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCollection(CollectionDto collectionDto)
        {
            var userId = GetUserId();
            var photo = await _photoService.AddPhotoAsync(collectionDto.Image);
            await _collectionService.AddCollection(collectionDto, photo, userId);
            return Created();
        }

        private int GetUserId()
        {
            var id = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new ArgumentNullException(nameof(User));
            return int.Parse(id);
        }
    }
}
