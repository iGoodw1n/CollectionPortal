using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CollectionLogicLayer.Helpers;
using CollectionLogicLayer.Consts;

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
            await _collectionService.AddCollection(collectionDto, photo, userId);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCollections([FromQuery]CollectionParams collectionParams)
        {
            var collections = await _collectionService.GetAll(collectionParams);
            return Ok(collections);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCollection([FromQuery] PaginationParams collectionParams, int id)
        {
            var collection = await _collectionService.GetCollection(id, collectionParams);
            return Ok(collection);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> GetCollectionForEdit(int id)
        {
            var collection = await _collectionService.GetCollection(id);
            return Ok(collection);
        }

        [Authorize]
        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateCollection(int id, [FromForm] UpdateCollectionDto updateCollection)
        {
            if (User.FindFirstValue(ClaimTypes.Role) == Names.ADMIN)
            {
                return await UpdateAsAdmin(id, updateCollection);
            }

            return await UpdateAsUser(id, updateCollection);
            
        }

        [Authorize]
        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id)
        {
            if (User.FindFirstValue(ClaimTypes.Role) == Names.ADMIN)
            {
                return DeleteAsAdmin(id);
            }

            return DeleteAsUser(id);
        }

        private async Task<IActionResult> UpdateAsUser(int id, UpdateCollectionDto updateCollection)
        {
            var userId = GetUserId();
            await _collectionService.UpdateCollection(id, updateCollection, userId);
            return NoContent();
        }

        private async Task<IActionResult> UpdateAsAdmin(int id, UpdateCollectionDto updateCollection)
        {
            await _collectionService.UpdateCollectionAsAdmin(id, updateCollection);
            return NoContent();
        }

        private async Task<IActionResult> DeleteAsAdmin(int id)
        {
            await _collectionService.DeleteWithAdminRole(id);
            return NoContent();
        }

        private async Task<IActionResult> DeleteAsUser(int id)
        {
            var userId = GetUserId();
            await _collectionService.Delete(id, userId);
            return NoContent();
        }

        private int GetUserId()
        {
            var id = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new UnauthorizedAccessException("User does not authorized");
            return int.Parse(id);
        }
    }
}
