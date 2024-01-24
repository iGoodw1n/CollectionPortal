using CollectionLogicLayer.Consts;
using CollectionLogicLayer.Helpers;
using CollectionLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CollectionPortalAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet("check")]
    public IActionResult CheckStatus()
    {
        foreach (var claim in User.Claims)
        {
            Console.WriteLine(claim.Type);
            Console.WriteLine(claim.Value);
        }
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var adminRole = User.FindFirstValue(ClaimTypes.Role);
        var userName = User.FindFirstValue(ClaimTypes.Name);
        return Ok(new { Id = id, IsAdmin = adminRole == Names.ADMIN, UserName = userName });
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams)
    {
        var users = await _accountService.GetAll(paginationParams);
        return Ok(users);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete]
    public async Task<IActionResult> DeleteUsers(List<int> ids)
    {
        await _accountService.DeleteUsers(ids);
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("block")]
    public async Task<IActionResult> BlockUsers(List<int> ids)
    {
        await _accountService.BlockUsers(ids);
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("unblock")]
    public async Task<IActionResult> UnblockUsers(List<int> ids)
    {
        await _accountService.UnblockUsers(ids);
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("setAdmin")]
    public async Task<IActionResult> SetAdminUsers(List<int> ids)
    {
        await _accountService.SetAdminUsers(ids);
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("removeAdmin")]
    public async Task<IActionResult> RemoveAdminUsers(List<int> ids)
    {
        await _accountService.RemoveAdminUsers(ids);
        return NoContent();
    }
}
