using CollectionDataLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace CollectionDataLayer.DTOs;

public class AppUserWithRole
{
    public AppUser User { get; set; } = null!;

    public IdentityRole<int> Role { get; set; } = null!;
}
