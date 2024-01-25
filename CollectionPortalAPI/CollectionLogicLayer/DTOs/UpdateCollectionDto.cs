namespace CollectionLogicLayer.DTOs;

public class UpdateCollectionDto
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int CategoryId { get; set; }
}
