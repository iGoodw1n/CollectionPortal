using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CollectionLogicLayer.Helpers;

namespace CollectionPortalAPI.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> CreateCollection(CreateCollectionDto collectionDto)
        {
            var userId = GetUserId();
            var photo = await _photoService.AddPhotoAsync(collectionDto.Image);
            await _collectionService.AddCollection(collectionDto, photo, userId!.Value);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCollections([FromQuery]CollectionParams collectionParams)
        {
            var userId = GetUserId();
            var collections = await _collectionService.GetAll(collectionParams, userId);
            return Ok(collections);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCollection([FromQuery] PaginationParams collectionParams, int id)
        {
            var collection = await _collectionService.GetCollection(id, collectionParams);
            return Ok(collection);
        }

        private int? GetUserId()
        {
            var id = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return id is not null ? int.Parse(id) : null;
        }
    }
}
