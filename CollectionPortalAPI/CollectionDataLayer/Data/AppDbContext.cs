using CollectionDataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollectionDataLayer.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser, IdentityRole<int>, int>(options)
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Collection> Collections { get; set; }

    public DbSet<Item> Items { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<Photo> Photos { get; set; }

    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Collection>()
            .HasOne(e => e.Photo)
            .WithOne(e => e.Collection)
            .HasForeignKey<Photo>(e => e.CollectionId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
    }
}
