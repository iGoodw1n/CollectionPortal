using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CollectionDataLayer.Entities;

public class AppUser : IdentityUser<int>
{
}
