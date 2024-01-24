using CollectionDataLayer.Consts;
using System.ComponentModel.DataAnnotations;

namespace CollectionDataLayer.Entities;

public class Comment
{
    public int Id { get; set; }

    [Required]
    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string Text { get; set; } = null!;

    public int UserId { get; set; }

    public AppUser User { get; set; } = null!;

    public int ItemId { get; set; }

    public Item Item { get; set; } = null!;
}
