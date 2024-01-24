using System.ComponentModel.DataAnnotations;

namespace CollectionLogicLayer.DTOs;

public class CommentDto
{
    [Required]
    public string Text { get; set; } = null!;

    public int ItemId { get; set; }
}
