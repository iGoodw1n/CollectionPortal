using CollectionDataLayer.Entities;
using CollectionLogicLayer.Helpers;

namespace CollectionLogicLayer.DTOs;

public class CollectionWithItemsDto : CollectionDto
{
    public PagedList<Item>? PaginatedItems { get; set; }
}


