using CollectionDataLayer.Entities;
using CollectionLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _tagService.GetAll();
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tags = await _tagService.Get(id);
            return Ok(tags);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(Tag tag)
        {
            await _tagService.AddTag(tag);
            return CreatedAtAction(nameof(Get), new { tag.Id }, tag);
        }
    }
}
