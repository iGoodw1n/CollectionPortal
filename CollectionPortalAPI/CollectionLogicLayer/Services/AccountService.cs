using AutoMapper;
using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Repositories;
using CollectionLogicLayer.Consts;
using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Helpers;
using Microsoft.AspNetCore.Identity;

namespace CollectionLogicLayer.Services;

internal class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> signManager;

    public AccountService(IUnitOfWork unitOfWork, IMapper mapper, RoleManager<IdentityRole<int>> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _roleManager = roleManager;
        _userManager = userManager;
        this.signManager = signManager;
    }

    public async Task BlockUsers(List<int> userIds)
    {
        var users = await GetUsers(userIds);
        await BlockUsers(users);
        await SaveChanges();
    }

    public async Task DeleteUsers(List<int> userIds)
    {
        var users = await GetUsers(userIds);
        DeleteUsers(users);
        await SaveChanges();
    }

    public async Task<PagedList<UserDto>> GetAll(PaginationParams paginationParams)
    {
        var queryParams = ParamsHelper.ConvertPaginationParamsToQuery(paginationParams);
        var users = await _unitOfWork.Users.GetAll(queryParams);
        return ConvertToPagedList(users, paginationParams);
    }

    public async Task RemoveAdminUsers(List<int> userIds)
    {
        var users = await GetUsers(userIds);
        await RemoveAdminRoleFromUsers(users);
    }

    public async Task SetAdminUsers(List<int> userIds)
    {
        var users = await GetUsers(userIds);
        await AddAdminRoleToUsers(users);
    }

    public async Task UnblockUsers(List<int> userIds)
    {
        var users = await GetUsers(userIds);
        UnblockUsers(users);
        await SaveChanges();
    }

    private PagedList<UserDto> ConvertToPagedList(QueryResultWithCount<AppUserWithRole> usersData, PaginationParams paginationParams)
    {
        var users = _mapper.Map<List<AppUserWithRole>, List<UserDto>>(usersData.Entities);
        return new PagedList<UserDto>(users, usersData.TotalCount, paginationParams.PageNumber, paginationParams.PageSize);
    }

    private Task<List<AppUser>> GetUsers(List<int> userIds)
    {
        return _unitOfWork.Users.GetAll(u => userIds.Contains(u.Id));
    }

    private async Task BlockUsers(List<AppUser> users)
    {
        foreach (var user in users)
        {
            await _userManager.UpdateSecurityStampAsync(user);
            user.LockoutEnabled = true;
            user.LockoutEnd = DateTime.UtcNow.AddDays(365);
        }
    }

    private static void UnblockUsers(List<AppUser> users)
    {
        foreach (var user in users)
        {
            user.LockoutEnabled = false;
            user.LockoutEnd = DateTime.UtcNow;
        }
    }

    private void DeleteUsers(List<AppUser> users)
    {
        foreach (var user in users)
        {
            _unitOfWork.Users.Delete(user);
        }
    }

    private Task SaveChanges()
    {
        return _unitOfWork.CompleteAsync();
    }

    private async Task RemoveAdminRoleFromUsers(List<AppUser> users)
    {
        foreach (var user in users)
        {
            var result = await _userManager.RemoveFromRoleAsync(user, Names.ADMIN);
            if (result.Errors.Any())
            {
                throw new HttpRequestException("Remove admin role errors: " + string.Join(", ", result.Errors));
            }
        }
    }

    private async Task AddAdminRoleToUsers(List<AppUser> users)
    {
        foreach (var user in users)
        {
            var result = await _userManager.AddToRoleAsync(user, Names.ADMIN);
            if (result.Errors.Any())
            {
                throw new HttpRequestException("Add admin role errors: " + string.Join(", ", result.Errors));
            }
        }
    }
}
