
using CollectionDataLayer.Entities;

namespace CollectionDataLayer.DTOs;

public class QueryResultForCollectionWithCount
{
    public int TotalCount { get; set; }

    public Collection? Collection { get; set; }
}
