using CollectionDataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollectionDataLayer.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Collection> Collections { get; set; }

    public DbSet<Item> Items { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<User> Users { get; set; }
}
