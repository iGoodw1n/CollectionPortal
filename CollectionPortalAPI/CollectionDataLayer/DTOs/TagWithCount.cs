using CollectionDataLayer.Entities;

namespace CollectionDataLayer.DTOs;

public class TagWithCount
{
    public Tag Tag { get; set; } = null!;

    public int Count { get; set; }
}
