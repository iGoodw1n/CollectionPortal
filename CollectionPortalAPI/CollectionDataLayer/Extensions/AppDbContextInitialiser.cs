using CollectionDataLayer.Data;
using CollectionDataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CollectionDataLayer.Extensions;

public class AppDbContextInitialiser(AppDbContext context)
{
    public async Task InitialiseAsync(IServiceScope scope)
    {
        await context.Database.MigrateAsync();
        var categories = await context.Categories.ToListAsync();
        if (categories.Count == 0)
        {
            context.Categories.AddRange(new[]
            {
                new Category() { Name = "Books" },
                new Category() { Name = "Signs" },
                new Category() { Name = "Stamps" },
                new Category() { Name = "Coins" },
            });
        }
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
        var roles = new[] { "Admin", "Member" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole<int>(role));
            }
        }
        await context.SaveChangesAsync();
    }
}
