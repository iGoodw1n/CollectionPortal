namespace CollectionDataLayer.Helpers;

public class QueryParams
{
    public int Skip { get; set; }

    public int Take { get; set; }

    public string OrderBy { get; set; } = null!;

    public string OrderType { get; set; } = null!;
}
