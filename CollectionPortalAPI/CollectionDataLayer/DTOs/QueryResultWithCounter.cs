namespace CollectionDataLayer.DTOs;

public class QueryResultWithCount<T> where T : class, new()
{
    public int TotalCount { get; set; }

    public List<T> Entities { get; set; } = [];
}
