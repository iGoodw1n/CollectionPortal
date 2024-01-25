using CollectionLogicLayer.Consts;
using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Helpers;
using CollectionLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

    [Authorize]
    [HttpPost("{id}")]
    public Task<IActionResult> Update(ItemDto itemDto, int id)
    {
        if (User.FindFirstValue(ClaimTypes.Role) == Names.ADMIN)
        {
            return UpdateAsAdmin(itemDto, id);
        }
        return UpdateAsUser(itemDto, id);
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

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PaginationParams paginationParams)
    {
        var items = await _itemService.GetItems(paginationParams);
        return Ok(items);
    }

    [HttpGet("bycollection/{id}")]
    public async Task<IActionResult> GetByCollection([FromQuery] PaginationParams paginationParams, int id)
    {
        var items = await _itemService.GetItemsByCollection(paginationParams, id);
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _itemService.GetItem(id);
        return Ok(item);
    }

    private async Task<IActionResult> UpdateAsUser(ItemDto itemDto, int id)
    {
        var userId = GetUserId();
        await _itemService.Update(itemDto, id, userId);
        return Created();
    }

    private async Task<IActionResult> UpdateAsAdmin(ItemDto itemDto, int id)
    {
        await _itemService.UpdateWithAdminRole(itemDto, id);
        return NoContent();
    }

    private async Task<IActionResult> DeleteAsAdmin(int id)
    {
        await _itemService.DeleteWithAdminRole(id);
        return NoContent();
    }

    private async Task<IActionResult> DeleteAsUser(int id)
    {
        var userId = GetUserId();
        await _itemService.Delete(id, userId);
        return NoContent();
    }

    private int GetUserId()
    {
        var id = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new UnauthorizedAccessException("User does not authorized");
        return int.Parse(id);
    }
}
