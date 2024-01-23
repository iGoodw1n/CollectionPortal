namespace CollectionLogicLayer.DTOs;

public class UserDto
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public bool IsBlocked { get; set; }

    public bool IsAdmin { get; set; }
}
