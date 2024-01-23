using CollectionDataLayer.Data;
using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace CollectionDataLayer.Repositories;

internal class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _context;

    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Delete(AppUser user)
    {
        _context.Users.Remove(user);
    }

    public Task<QueryResultWithCount<AppUserWithRole>> GetAll(QueryParams queryParams)
    {
        var query = from user in _context.Users
                    join userRole in _context.UserRoles on user.Id equals userRole.UserId into userRole
                    from ur in userRole.DefaultIfEmpty()
                    join role in _context.Roles on ur.RoleId equals role.Id into userWithRole
                    from uwr in userWithRole.DefaultIfEmpty()
                    orderby $"{queryParams.OrderBy} {queryParams.OrderType}"
                    select new AppUserWithRole() { User = user, Role = uwr };

        return GetQuery(query, queryParams);
    }

    public Task<List<AppUser>> GetAll(Expression<Func<AppUser, bool>> filter)
    {
        return _context.Users.Where(filter).ToListAsync();
    }

    public Task<List<AppUser>> GetAllWithRoles(Expression<Func<AppUser, bool>> filter)
    {
        throw new NotImplementedException();
    }

    private async Task<QueryResultWithCount<AppUserWithRole>> GetQuery(IQueryable<AppUserWithRole> query, QueryParams queryParams)
    {
        var count = await query.CountAsync();
        var users = await query.Skip(queryParams.Skip).Take(queryParams.Take).ToListAsync();
        return new QueryResultWithCount<AppUserWithRole> { TotalCount = count, Entities = users };
    }
}
