using CollectionDataLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace CollectionDataLayer.Extensions;

public class AppDbContextInitialiser(AppDbContext context)
{
    public async Task InitialiseAsync()
    {
        await context.Database.MigrateAsync();
    }
}
