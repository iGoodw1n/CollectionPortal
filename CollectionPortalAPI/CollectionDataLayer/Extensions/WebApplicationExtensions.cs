using CollectionDataLayer.Consts;
using CollectionDataLayer.Data;
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

        return services;
    }
}
