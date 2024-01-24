using CollectionDataLayer.Consts;
using CollectionLogicLayer.Consts;
using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Helpers;
using CollectionLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CollectionPortalAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public CommentsController(ICommentService commentService, RoleManager<IdentityRole<int>> roleManager)
        {
            _commentService = commentService;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentDto comment)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value  ?? throw new UnauthorizedAccessException("User does not authorized");
            await _commentService.Add(comment);
            return Created();
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id)
        {
            if (User.FindFirstValue(ClaimTypes.Role) == Names.ADMIN)
            {
                return DeleteAsAdmin(id);
            }

            return DeleteAsUser(id);
        }

        [HttpGet("byitem/{id}")]
        public async Task<IActionResult> GetAllByItem([FromQuery] PaginationParams paginationParams, int id)
        {
            var comments = await _commentService.GetAllByItem(paginationParams, id);
            return Ok(comments);
        }

        private async Task<IActionResult> DeleteAsAdmin(int id)
        {
            await _commentService.DeleteWithAdminRole(id);
            return NoContent();
        }

        private async Task<IActionResult> DeleteAsUser(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new UnauthorizedAccessException("User does not authorized");
            await _commentService.Delete(id, userId);
            return NoContent();
        }
    }
}
