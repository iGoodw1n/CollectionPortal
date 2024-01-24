namespace CollectionLogicLayer.DTOs;

public class CommentWithUser
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public DateTime CreationDate { get; set; }
}
