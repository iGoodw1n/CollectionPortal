using CollectionDataLayer.Consts;
using CollectionDataLayer.Data;
using CollectionDataLayer.Entities;
using CollectionDataLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CollectionDataLayer.Extensions;
public static class WebApplicationExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable(EnvVars.DbConnection) ?? throw new ArgumentException("Connection string is empty");

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddIdentityCore<AppUser>()
            .AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddApiEndpoints();

        services.AddScoped<ICollectionRepository, CollectionRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<AppDbContextInitialiser>();

        return services;
    }
}
