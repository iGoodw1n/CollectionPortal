using CollectionDataLayer.DTOs;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Helpers;
using System.Linq.Expressions;

namespace CollectionDataLayer.Repositories;

public interface IAccountRepository
{
    public Task<QueryResultWithCount<AppUserWithRole>> GetAll(QueryParams queryParams);

    public Task<List<AppUser>> GetAll(Expression<Func<AppUser, bool>> filter);

    public Task<List<AppUser>> GetAllWithRoles(Expression<Func<AppUser, bool>> filter);

    public void Delete(AppUser user);
}
