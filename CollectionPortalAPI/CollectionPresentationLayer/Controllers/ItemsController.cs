using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Helpers;
using CollectionLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionPortalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Add(ItemDto itemDto)
    {
        await _itemService.AddItem(itemDto);
        return Created();
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]PaginationParams paginationParams)
    {
        var items = await _itemService.GetItems(paginationParams);
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _itemService.GetItem(id);
        return Ok(item);
    }
}
