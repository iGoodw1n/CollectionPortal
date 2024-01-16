﻿using CollectionDataLayer.Entities;
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
}
