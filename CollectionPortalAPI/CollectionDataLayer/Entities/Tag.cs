using CollectionDataLayer.Consts;
using System.ComponentModel.DataAnnotations;

namespace CollectionDataLayer.Entities;

public class Tag
{
    public int Id { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string Name { get; set; } = null!;

    public List<Item> Items { get; set; } = [];
}
