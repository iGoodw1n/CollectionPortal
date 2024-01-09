using System.ComponentModel.DataAnnotations;

namespace CollectionDataLayer.Entities;

public class Category
{
    public int Id { get; set; }

    [MinLength(3)]
    public string Name { get; set; } = null!;
}
