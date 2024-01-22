using CollectionLogicLayer.DTOs;
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
}
