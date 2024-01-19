namespace CollectionDataLayer.Entities;

public class Photo
{
    public int Id { get; set; }
    public string Url { get; set; } = null!;
    public string PublicId { get; set; } = null!;
    public int CollectionId { get; set; }
    public Collection Collection { get; set; } = null!;
}
