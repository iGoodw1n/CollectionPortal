using CollectionLogicLayer.DTOs;

namespace CollectionLogicLayer.Services;

public interface IItemService
{
    Task AddItem(ItemDto itemDto);
}
