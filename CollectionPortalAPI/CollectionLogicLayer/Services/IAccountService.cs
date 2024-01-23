using CollectionLogicLayer.DTOs;
using CollectionLogicLayer.Helpers;

namespace CollectionLogicLayer.Services;

public interface IAccountService
{
    public Task<PagedList<UserDto>> GetAll(PaginationParams paginationParams);

    public Task BlockUsers(List<int> userIds);

    public Task UnblockUsers(List<int> userIds);

    public Task SetAdminUsers(List<int> userIds);

    public Task RemoveAdminUsers(List<int> userIds);

    public Task DeleteUsers(List<int> userIds);
}
